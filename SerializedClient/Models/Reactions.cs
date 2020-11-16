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

    public partial class Reactions
    {
        /// <summary>
        /// Initializes a new instance of the Reactions class.
        /// </summary>
        public Reactions()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Reactions class.
        /// </summary>
        public Reactions(IList<Reaction> reactionsProperty)
        {
            ReactionsProperty = reactionsProperty;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reactions")]
        public IList<Reaction> ReactionsProperty { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ReactionsProperty == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ReactionsProperty");
            }
            if (ReactionsProperty != null)
            {
                foreach (var element in ReactionsProperty)
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
