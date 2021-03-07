using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SerializedClient;
using SerializedClient.Models;

namespace SerializedClientTest
{
    [TestClass]
    public class ScenarioTest
    {
        private readonly string orderType = "order";
        private readonly string notifierName = "new-order-notifier";
        private readonly string ordersProjections = "orders";
        private readonly string orderTotalsProjection = "order-totals";

        private readonly Guid orderId1 = Guid.Parse("5ee5a820-2a45-44db-bc1d-adb2635586e6");
        private readonly Guid orderId2 = Guid.Parse("f19cf83e-099a-4499-9f06-cdf5aa8f0006");

        private readonly string accessKey = System.Environment.GetEnvironmentVariable("SERIALIZED_ACCESS_KEY");
        private readonly string secretAccessKey = System.Environment.GetEnvironmentVariable("SERIALIZED_SECRET_ACCESS_KEY");


        [TestMethod]
        public void TestScenario()
        {
            try
            {
                Debug.WriteLine("Running scenario test... " + DateTime.Now);

                var credentials = new SerializedClientCredentials(accessKey, secretAccessKey);
                var client = new Serialized(credentials);

                cleanUpPreviousExecutionResult(client);
                setUpDefinitions(client);

                // Verify no feeds exists as no aggregates exists.
                Assert.AreEqual(0, client.ListFeeds().Feeds.Count);

                // Store events and verify loading of aggregates.
                storeAndLoadEvents(client);

                // Verify one feed exists as one aggregate type (order) now exists.
                Assert.AreEqual(1, client.ListFeeds().Feeds.Count);

                readAndVerifyAllFeed(client);

                readAndVerifyOrderFeed(client);

                // Projections are created async so we have to wait a while.
                Thread.Sleep(2000);

                getAndVerifyOrderProjections(client);

                getAndVerifyOrderTotalsProjection(client);

                filterOrderProjectionsByReference(client, "PAID");

                // Verify no scheduled reactions exists.
                Assert.AreEqual(0, client.ListScheduledReactions().ReactionsProperty.Count);

                // Verify the two OrderPlaced events on orderId1 and orderId2 resulted in successfully triggered reactions (new order notifications).
                Assert.AreEqual(2, client.ListTriggeredReactions().ReactionsProperty.Count);

                Debug.WriteLine("Scenario test completed!");
            }
            catch (HttpOperationException hex)
            {
                Debug.WriteLine(hex);
                Debug.WriteLine("Error, code: " + hex.Response.StatusCode);
                Debug.WriteLine("Request: " + hex.Request.Content);
                Debug.WriteLine("Response: " + hex.Response.Content);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Assert.Fail();
            }
        }

        private void cleanUpPreviousExecutionResult(Serialized client)
        {
            Debug.WriteLine("Deleting Reaction: " + notifierName);
            client.DeleteReactionDefinition(notifierName);

            Debug.WriteLine("Deleting aggregates of type: " + orderType);
            var deleteToken = client.DeleteAggregatesByType(orderType);
            client.DeleteAggregatesByType(orderType, deleteToken: deleteToken.DeleteToken);

            Debug.WriteLine("Clearing single projections: " + ordersProjections);
            client.RecreateSingleProjections(ordersProjections);

            Debug.WriteLine("Clearing aggregated projection: " + orderTotalsProjection);
            client.RecreateAggregatedProjections(orderTotalsProjection);
        }

        public void setUpDefinitions(Serialized client)
        {
            Debug.WriteLine("Setting up Reaction: " + notifierName);
            Assert.AreEqual(0, client.ListReactionDefinitions().Definitions.Count);
            var reactionDefinition = createNotifierReaction();
            client.CreateOrUpdateReactionDefinition(notifierName, reactionDefinition);

            Debug.WriteLine("Setting up single projection: " + ordersProjections);
            var ordersProjectionDefinition = createSingleProjectionDefinition(ordersProjections);
            client.CreateProjectionDefinition(ordersProjectionDefinition);

            Debug.WriteLine("Setting up aggregated projection: " + ordersProjections);
            var orderTotalsProjectionDefinition = createAggregatedProjectionDefinition(orderTotalsProjection);
            client.CreateProjectionDefinition(orderTotalsProjectionDefinition);
        }

        private ReactionDefinition createNotifierReaction()
        {
            var definition = new ReactionDefinition();
            definition.ReactionName = notifierName;
            definition.FeedName = orderType;
            definition.ReactOnEventType = "OrderPlaced";
            definition.Action = new SerializedClient.Models.Action(actionType: "HTTP_POST", targetUri: "https://httpbin.org/post", signingSecret: "my-secret");
            return definition;
        }

        private ProjectionDefinition createSingleProjectionDefinition(string projectionName)
        {
            var definition = new ProjectionDefinition();
            definition.ProjectionName = projectionName;
            definition.FeedName = orderType;
            definition.Handlers = new List<Handler>();
            definition.Handlers.Add(new Handler(eventType: "OrderPlaced", functions: new List<Function>()
            {
                 new Function(functionProperty: "set", targetSelector: "$.projection.status", rawData: "PLACED"),
                 new Function(functionProperty: "setref", targetSelector: "$.projection.status"),
                 new Function(functionProperty: "set", targetSelector: "$.projection.orderAmount", eventSelector: "$.event.orderAmount")
            }));

            definition.Handlers.Add(new Handler(eventType: "OrderPaid", functions: new List<Function>()
            {
                 new Function(functionProperty: "set", targetSelector: "$.projection.status", rawData: "PAID"),
                 new Function(functionProperty: "setref", targetSelector: "$.projection.status")
            }));

            return definition;
        }

        private ProjectionDefinition createAggregatedProjectionDefinition(string projectionName)
        {
            var definition = new ProjectionDefinition();
            definition.ProjectionName = projectionName;
            definition.FeedName = orderType;
            definition.Aggregated = true;
            definition.Handlers = new List<Handler>();
            definition.Handlers.Add(new Handler(eventType: "OrderPlaced", functions: new List<Function>()
            {
                 new Function(functionProperty: "add", targetSelector: "$.projection.orderAmount", eventSelector: "$.event.orderAmount"),
                 new Function(functionProperty: "inc", targetSelector: "$.projection.orderCount")
            }));

            return definition;
        }

        private void storeAndLoadEvents(Serialized client)
        {
            Debug.WriteLine("Storing events on aggregate: " + orderType);

            client.StoreEvents(orderType, orderId1, new EventBatch(new List<EventModel>()
            {
                new EventModel("OrderPlaced", Guid.NewGuid(), new Dictionary<string, object>()
                {
                    {"customerId", "some-test-id-1"},
                    {"orderAmount", 12345},
                    {"placedAt", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}
                }
                , "encrypted-and-secret-payload")
            }, 0));

            client.StoreEvents(orderType, orderId1, new EventBatch(new List<EventModel>()
            {
                new EventModel("OrderPaid", Guid.NewGuid(), new Dictionary<string, object>()
                {
                    {"customerId", "some-test-id-1"},
                    {"paidAt", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}
                })
            }, 1));

            client.StoreEvents(orderType, orderId2, new EventBatch(new List<EventModel>()
            {
                new EventModel("OrderPlaced", Guid.NewGuid(), new Dictionary<string, object>()
                {
                    {"customerId", "some-test-id-2"},
                    {"orderAmount", 67890},
                    {"placedAt", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}
                }
                , "another-encrypted-and-secret-payload")
            }, 0));


            Debug.WriteLine("Loading aggregate: " + orderId1);

            var aggregate1 = client.LoadEvents(orderType, orderId1);

            Assert.AreEqual(false, aggregate1.HasMore);
            Assert.AreEqual(orderId1, aggregate1.AggregateId);
            Assert.AreEqual(orderType, aggregate1.AggregateType);
            Assert.AreEqual(2, aggregate1.AggregateVersion);
            Assert.AreEqual(2, aggregate1.Events.Count);

            var enumerator = aggregate1.Events.GetEnumerator();

            enumerator.MoveNext();

            var eventModel = enumerator.Current;
            Assert.AreEqual("OrderPlaced", eventModel.EventType);
            Assert.AreEqual("encrypted-and-secret-payload", eventModel.EncryptedData);
            Assert.IsNotNull(eventModel.Data);

            enumerator.MoveNext();

            eventModel = enumerator.Current;
            Assert.AreEqual("OrderPaid", eventModel.EventType);
            Assert.IsNull(eventModel.EncryptedData);
            Assert.IsNotNull(eventModel.Data);
        }

        private void readAndVerifyAllFeed(Serialized client)
        {
            Debug.WriteLine("Reading ALL feed");

            var allFeed = client.FeedEvents();
            var feeEnumerator = allFeed.Entries.GetEnumerator();
            Assert.AreEqual(3, allFeed.Entries.Count);

            feeEnumerator.MoveNext();
            Assert.AreEqual(orderId1, feeEnumerator.Current.AggregateId);

            feeEnumerator.MoveNext();
            Assert.AreEqual(orderId1, feeEnumerator.Current.AggregateId);

            feeEnumerator.MoveNext();
            Assert.AreEqual(orderId2, feeEnumerator.Current.AggregateId);
        }

        private void readAndVerifyOrderFeed(Serialized client)
        {
            Debug.WriteLine("Reading feed: " + orderType);

            var orderFeed = client.FeedEventsByType(orderType);
            var feedEnumerator = orderFeed.Entries.GetEnumerator();
            Assert.AreEqual(3, orderFeed.Entries.Count);

            // First
            feedEnumerator.MoveNext();
            Assert.AreEqual(orderId1, feedEnumerator.Current.AggregateId);
            var eventEnumerator = feedEnumerator.Current.Events.GetEnumerator();
            eventEnumerator.MoveNext();

            var eventData = (JObject)eventEnumerator.Current.Data;
            Assert.AreEqual("OrderPlaced", eventEnumerator.Current.EventType);
            Assert.AreEqual("some-test-id-1", eventData["customerId"]);
            Assert.AreEqual(12345, eventData["orderAmount"]);
            Assert.IsNotNull(eventData["placedAt"]);

            // Second
            feedEnumerator.MoveNext();
            Assert.AreEqual(orderId1, feedEnumerator.Current.AggregateId);
            eventEnumerator = feedEnumerator.Current.Events.GetEnumerator();
            eventEnumerator.MoveNext();

            eventData = (JObject)eventEnumerator.Current.Data;
            Assert.AreEqual("OrderPaid", eventEnumerator.Current.EventType);
            Assert.AreEqual("some-test-id-1", eventData["customerId"]);
            Assert.IsNotNull(eventData["paidAt"]);

            // Third
            feedEnumerator.MoveNext();
            Assert.AreEqual(orderId2, feedEnumerator.Current.AggregateId);
            eventEnumerator = feedEnumerator.Current.Events.GetEnumerator();
            eventEnumerator.MoveNext();

            eventData = (JObject)eventEnumerator.Current.Data;
            Assert.AreEqual("OrderPlaced", eventEnumerator.Current.EventType);
            Assert.AreEqual("some-test-id-2", eventData["customerId"]);
            Assert.AreEqual(67890, eventData["orderAmount"]);
            Assert.IsNotNull(eventData["placedAt"]);
        }

        private void getAndVerifyOrderProjections(Serialized client)
        {
            Debug.WriteLine("Getting single projections: " + ordersProjections);

            // Verify count
            var orderCount = client.GetSingleProjectionCount(ordersProjections);
            Assert.AreEqual(2, orderCount.Count);

            // Verify list
            var orders = client.ListSingleProjections(ordersProjections);
            Assert.AreEqual(false, orders.HasMore);
            Assert.AreEqual(2, orders.ProjectionsProperty.Count);

            // First
            var order = client.GetSingleProjection(ordersProjections, orderId1);
            Assert.AreEqual(orderId1, Guid.Parse(order.ProjectionId));
            var projectionData = (JObject)order.Data;
            Assert.AreEqual(12345, projectionData["orderAmount"]);
            Assert.AreEqual("PAID", projectionData["status"]);

            // Second
            order = client.GetSingleProjection(ordersProjections, orderId2);
            Assert.AreEqual(orderId2, Guid.Parse(order.ProjectionId));
            projectionData = (JObject)order.Data;
            Assert.AreEqual(67890, projectionData["orderAmount"]);
            Assert.AreEqual("PLACED", projectionData["status"]);
        }

        private void filterOrderProjectionsByReference(Serialized client, string reference)
        {
            Debug.WriteLine("Filtering single projections by reference: " + ordersProjections);

            var orders = client.ListSingleProjections(ordersProjections, reference: reference);
            Assert.AreEqual(false, orders.HasMore);
            Assert.AreEqual(1, orders.ProjectionsProperty.Count);
        }

        private void getAndVerifyOrderTotalsProjection(Serialized client)
        {
            Debug.WriteLine("Getting aggregated projection: " + orderTotalsProjection);

            var orderTotals = client.GetAggregatedProjection(orderTotalsProjection);
            Assert.AreEqual(orderTotalsProjection, orderTotals.ProjectionId);
            var projectionData = (JObject)orderTotals.Data;
            Assert.AreEqual(80235, projectionData["orderAmount"]);
            Assert.AreEqual(2, projectionData["orderCount"]);
        }

    }

}
