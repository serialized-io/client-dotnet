// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SerializedClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ProjectionInfo
    {
        /// <summary>
        /// Initializes a new instance of the ProjectionInfo class.
        /// </summary>
        public ProjectionInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ProjectionInfo class.
        /// </summary>
        public ProjectionInfo(string projectionName = default(string), string feedName = default(string), bool? aggregated = default(bool?), int? projectionsCount = default(int?))
        {
            ProjectionName = projectionName;
            FeedName = feedName;
            Aggregated = aggregated;
            ProjectionsCount = projectionsCount;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "projectionName")]
        public string ProjectionName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "feedName")]
        public string FeedName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "aggregated")]
        public bool? Aggregated { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "projectionsCount")]
        public int? ProjectionsCount { get; set; }

    }
}
