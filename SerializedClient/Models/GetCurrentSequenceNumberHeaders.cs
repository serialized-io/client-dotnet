// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SerializedClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for getCurrentSequenceNumber operation.
    /// </summary>
    public partial class GetCurrentSequenceNumberHeaders
    {
        /// <summary>
        /// Initializes a new instance of the GetCurrentSequenceNumberHeaders
        /// class.
        /// </summary>
        public GetCurrentSequenceNumberHeaders()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GetCurrentSequenceNumberHeaders
        /// class.
        /// </summary>
        /// <param name="serializedSequenceNumberCurrent">Current sequence
        /// number at feed head</param>
        public GetCurrentSequenceNumberHeaders(int? serializedSequenceNumberCurrent = default(int?))
        {
            SerializedSequenceNumberCurrent = serializedSequenceNumberCurrent;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets current sequence number at feed head
        /// </summary>
        [JsonProperty(PropertyName = "Serialized-SequenceNumber-Current")]
        public int? SerializedSequenceNumberCurrent { get; set; }

    }
}
