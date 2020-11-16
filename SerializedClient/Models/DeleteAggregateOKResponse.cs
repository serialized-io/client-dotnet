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
    /// The delete token, valid for ten minutes.
    /// </summary>
    public partial class DeleteAggregateOKResponse
    {
        /// <summary>
        /// Initializes a new instance of the DeleteAggregateOKResponse class.
        /// </summary>
        public DeleteAggregateOKResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DeleteAggregateOKResponse class.
        /// </summary>
        public DeleteAggregateOKResponse(System.Guid? deleteToken = default(System.Guid?))
        {
            DeleteToken = deleteToken;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deleteToken")]
        public System.Guid? DeleteToken { get; set; }

    }
}