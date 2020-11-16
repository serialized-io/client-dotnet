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

    public partial class Feed
    {
        /// <summary>
        /// Initializes a new instance of the Feed class.
        /// </summary>
        public Feed()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Feed class.
        /// </summary>
        /// <param name="hasMore">Indicates if there are more events
        /// available.</param>
        public Feed(IList<FeedEntry> entries = default(IList<FeedEntry>), bool? hasMore = default(bool?), int? currentSequenceNumber = default(int?))
        {
            Entries = entries;
            HasMore = hasMore;
            CurrentSequenceNumber = currentSequenceNumber;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public IList<FeedEntry> Entries { get; set; }

        /// <summary>
        /// Gets or sets indicates if there are more events available.
        /// </summary>
        [JsonProperty(PropertyName = "hasMore")]
        public bool? HasMore { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "currentSequenceNumber")]
        public int? CurrentSequenceNumber { get; set; }

    }
}
