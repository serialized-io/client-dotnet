// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SerializedClient.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class FeedEntry
    {
        /// <summary>
        /// Initializes a new instance of the FeedEntry class.
        /// </summary>
        public FeedEntry()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FeedEntry class.
        /// </summary>
        public FeedEntry(int? sequenceNumber = default(int?), System.Guid? aggregateId = default(System.Guid?), long? timestamp = default(long?), IList<EventModel> events = default(IList<EventModel>))
        {
            SequenceNumber = sequenceNumber;
            AggregateId = aggregateId;
            Timestamp = timestamp;
            Events = events;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequenceNumber")]
        public int? SequenceNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "aggregateId")]
        public System.Guid? AggregateId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public long? Timestamp { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "events")]
        public IList<EventModel> Events { get; set; }

    }
}
