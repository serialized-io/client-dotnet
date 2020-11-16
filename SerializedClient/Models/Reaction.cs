// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SerializedClient.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Reaction
    {
        /// <summary>
        /// Initializes a new instance of the Reaction class.
        /// </summary>
        public Reaction()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Reaction class.
        /// </summary>
        /// <param name="reactionName">Unique name of the action</param>
        public Reaction(System.Guid? reactionId = default(System.Guid?), string reactionName = default(string), string aggregateType = default(string), System.Guid? aggregateId = default(System.Guid?), System.Guid? eventId = default(System.Guid?), long? createdAt = default(long?), long? triggerAt = default(long?), long? finishedAt = default(long?))
        {
            ReactionId = reactionId;
            ReactionName = reactionName;
            AggregateType = aggregateType;
            AggregateId = aggregateId;
            EventId = eventId;
            CreatedAt = createdAt;
            TriggerAt = triggerAt;
            FinishedAt = finishedAt;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reactionId")]
        public System.Guid? ReactionId { get; set; }

        /// <summary>
        /// Gets or sets unique name of the action
        /// </summary>
        [JsonProperty(PropertyName = "reactionName")]
        public string ReactionName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "aggregateType")]
        public string AggregateType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "aggregateId")]
        public System.Guid? AggregateId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "eventId")]
        public System.Guid? EventId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdAt")]
        public long? CreatedAt { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "triggerAt")]
        public long? TriggerAt { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "finishedAt")]
        public long? FinishedAt { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ReactionName != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(ReactionName, "^[a-z0-9]+[a-z0-9\\-_]+[a-z0-9]+$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "ReactionName", "^[a-z0-9]+[a-z0-9\\-_]+[a-z0-9]+$");
                }
            }
            if (AggregateType != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(AggregateType, "^[a-z0-9]+[a-z0-9\\-_]+[a-z0-9]+$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "AggregateType", "^[a-z0-9]+[a-z0-9\\-_]+[a-z0-9]+$");
                }
            }
        }
    }
}