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

    public partial class Tenants
    {
        /// <summary>
        /// Initializes a new instance of the Tenants class.
        /// </summary>
        public Tenants()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Tenants class.
        /// </summary>
        public Tenants(IList<Tenant> definitions = default(IList<Tenant>))
        {
            Definitions = definitions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "definitions")]
        public IList<Tenant> Definitions { get; set; }

    }
}
