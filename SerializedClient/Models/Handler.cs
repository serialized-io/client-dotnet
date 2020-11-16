// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SerializedClient.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Handler
    {
        /// <summary>
        /// Initializes a new instance of the Handler class.
        /// </summary>
        public Handler()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Handler class.
        /// </summary>
        /// <param name="eventType">Event type to match the handler
        /// against</param>
        /// <param name="functionUri">URI pointing to function when using
        /// external event projector.</param>
        /// <param name="idField">Field in the projection to use as id field in
        /// queries. Defaults to the aggregate id.</param>
        /// <param name="functions">The functions to apply for matching events.
        /// Will run in specified order</param>
        public Handler(string eventType, string functionUri = default(string), string idField = default(string), IList<Function> functions = default(IList<Function>))
        {
            EventType = eventType;
            FunctionUri = functionUri;
            IdField = idField;
            Functions = functions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets event type to match the handler against
        /// </summary>
        [JsonProperty(PropertyName = "eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets URI pointing to function when using external event
        /// projector.
        /// </summary>
        [JsonProperty(PropertyName = "functionUri")]
        public string FunctionUri { get; set; }

        /// <summary>
        /// Gets or sets field in the projection to use as id field in queries.
        /// Defaults to the aggregate id.
        /// </summary>
        [JsonProperty(PropertyName = "idField")]
        public string IdField { get; set; }

        /// <summary>
        /// Gets or sets the functions to apply for matching events. Will run
        /// in specified order
        /// </summary>
        [JsonProperty(PropertyName = "functions")]
        public IList<Function> Functions { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (EventType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EventType");
            }
            if (Functions != null)
            {
                foreach (var element in Functions)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
