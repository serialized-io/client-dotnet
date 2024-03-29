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

    public partial class ReactionDefinition
    {
        /// <summary>
        /// Initializes a new instance of the ReactionDefinition class.
        /// </summary>
        public ReactionDefinition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ReactionDefinition class.
        /// </summary>
        /// <param name="reactionName">Unique name of the action</param>
        /// <param name="feedName">Name of the feed</param>
        /// <param name="reactOnEventType">Event type to react on</param>
        /// <param name="description">Definition description</param>
        /// <param name="cancelOnEventTypes">Event types to cancel reaction
        /// scheduled in the future</param>
        /// <param name="triggerTimeField">Optional path to event data field
        /// containing trigger time. If not specified, trigger time will be
        /// ASAP. Dot notation supported.</param>
        /// <param name="offset">Optional trigger time offset. Defined in the
        /// ISO-8601 duration format (PnDTnHnMn.nS). May be negative if
        /// 'triggerTimeField' is set.</param>
        public ReactionDefinition(string reactionName, string feedName, string reactOnEventType, Action action, string description = default(string), IList<string> cancelOnEventTypes = default(IList<string>), string triggerTimeField = default(string), string offset = default(string))
        {
            ReactionName = reactionName;
            FeedName = feedName;
            Description = description;
            ReactOnEventType = reactOnEventType;
            CancelOnEventTypes = cancelOnEventTypes;
            TriggerTimeField = triggerTimeField;
            Offset = offset;
            Action = action;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unique name of the action
        /// </summary>
        [JsonProperty(PropertyName = "reactionName")]
        public string ReactionName { get; set; }

        /// <summary>
        /// Gets or sets name of the feed
        /// </summary>
        [JsonProperty(PropertyName = "feedName")]
        public string FeedName { get; set; }

        /// <summary>
        /// Gets or sets definition description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets event type to react on
        /// </summary>
        [JsonProperty(PropertyName = "reactOnEventType")]
        public string ReactOnEventType { get; set; }

        /// <summary>
        /// Gets or sets event types to cancel reaction scheduled in the future
        /// </summary>
        [JsonProperty(PropertyName = "cancelOnEventTypes")]
        public IList<string> CancelOnEventTypes { get; set; }

        /// <summary>
        /// Gets or sets optional path to event data field containing trigger
        /// time. If not specified, trigger time will be ASAP. Dot notation
        /// supported.
        /// </summary>
        [JsonProperty(PropertyName = "triggerTimeField")]
        public string TriggerTimeField { get; set; }

        /// <summary>
        /// Gets or sets optional trigger time offset. Defined in the ISO-8601
        /// duration format (PnDTnHnMn.nS). May be negative if
        /// 'triggerTimeField' is set.
        /// </summary>
        [JsonProperty(PropertyName = "offset")]
        public string Offset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public Action Action { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ReactionName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ReactionName");
            }
            if (FeedName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FeedName");
            }
            if (ReactOnEventType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ReactOnEventType");
            }
            if (Action == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Action");
            }
            if (ReactionName != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(ReactionName, "^[a-z0-9]+[a-z0-9\\-_]+[a-z0-9]+$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "ReactionName", "^[a-z0-9]+[a-z0-9\\-_]+[a-z0-9]+$");
                }
            }
            if (Action != null)
            {
                Action.Validate();
            }
        }
    }
}
