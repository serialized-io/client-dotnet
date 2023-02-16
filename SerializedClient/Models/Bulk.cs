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

    public partial class Bulk
    {
        /// <summary>
        /// Initializes a new instance of the Bulk class.
        /// </summary>
        public Bulk()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Bulk class.
        /// </summary>
        /// <param name="batches">Array of domain event batches</param>
        public Bulk(IList<BulkEventBatch> batches)
        {
            Batches = batches;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets array of domain event batches
        /// </summary>
        [JsonProperty(PropertyName = "batches")]
        public IList<BulkEventBatch> Batches { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Batches == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Batches");
            }
            if (Batches != null)
            {
                foreach (var element in Batches)
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
