// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SerializedClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class FeedProgress
    {
        /// <summary>
        /// Initializes a new instance of the FeedProgress class.
        /// </summary>
        public FeedProgress()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FeedProgress class.
        /// </summary>
        /// <param name="sequenceNumber">Current processed sequence
        /// number</param>
        /// <param name="atHead">True if the projection engine has reached head
        /// at least once, i.e. a replay has been done.</param>
        public FeedProgress(int? sequenceNumber = default(int?), bool? atHead = default(bool?))
        {
            SequenceNumber = sequenceNumber;
            AtHead = atHead;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets current processed sequence number
        /// </summary>
        [JsonProperty(PropertyName = "sequenceNumber")]
        public int? SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets true if the projection engine has reached head at
        /// least once, i.e. a replay has been done.
        /// </summary>
        [JsonProperty(PropertyName = "atHead")]
        public bool? AtHead { get; set; }

    }
}
