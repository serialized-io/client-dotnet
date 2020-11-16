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

    public partial class EventBatch
    {
        /// <summary>
        /// Initializes a new instance of the EventBatch class.
        /// </summary>
        public EventBatch()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EventBatch class.
        /// </summary>
        /// <param name="expectedVersion">Optional version number enabling
        /// optimistic concurrency control in a multi-threaded
        /// scenario.</param>
        public EventBatch(IList<EventModel> events, int? expectedVersion = default(int?))
        {
            Events = events;
            ExpectedVersion = expectedVersion;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "events")]
        public IList<EventModel> Events { get; set; }

        /// <summary>
        /// Gets or sets optional version number enabling optimistic
        /// concurrency control in a multi-threaded scenario.
        /// </summary>
        [JsonProperty(PropertyName = "expectedVersion")]
        public int? ExpectedVersion { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Events == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Events");
            }
            if (Events != null)
            {
                foreach (var element in Events)
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
