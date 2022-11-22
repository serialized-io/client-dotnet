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

    public partial class FeedInfo
    {
        /// <summary>
        /// Initializes a new instance of the FeedInfo class.
        /// </summary>
        public FeedInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FeedInfo class.
        /// </summary>
        public FeedInfo(string aggregateType = default(string), int? aggregateCount = default(int?), int? batchCount = default(int?), int? eventCount = default(int?), int? currentSequenceNumber = default(int?))
        {
            AggregateType = aggregateType;
            AggregateCount = aggregateCount;
            BatchCount = batchCount;
            EventCount = eventCount;
            CurrentSequenceNumber = currentSequenceNumber;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "aggregateType")]
        public string AggregateType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "aggregateCount")]
        public int? AggregateCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "batchCount")]
        public int? BatchCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "eventCount")]
        public int? EventCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "currentSequenceNumber")]
        public int? CurrentSequenceNumber { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
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