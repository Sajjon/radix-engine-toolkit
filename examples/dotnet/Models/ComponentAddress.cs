/*
 * Transaction Lib
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// ComponentAddress
    /// </summary>
    [DataContract]
    public partial class ComponentAddress : Value, IEquatable<ComponentAddress>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentAddress" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ComponentAddress() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentAddress" /> class.
        /// </summary>
        /// <param name="address">address (required).</param>
        public ComponentAddress(string address = default(string)) : base("ComponentAddress")
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new InvalidDataException("address is a required property for ComponentAddress and cannot be null");
            }
            else
            {
                this.Address = address;
            }

        }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ComponentAddress {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ComponentAddress);
        }

        /// <summary>
        /// Returns true if ComponentAddress instances are equal
        /// </summary>
        /// <param name="input">Instance of ComponentAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ComponentAddress input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
