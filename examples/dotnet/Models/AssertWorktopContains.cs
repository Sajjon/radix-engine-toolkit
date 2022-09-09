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
    /// AssertWorktopContains
    /// </summary>
    [DataContract]
    public partial class AssertWorktopContains : Instruction, IEquatable<AssertWorktopContains>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssertWorktopContains" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AssertWorktopContains() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AssertWorktopContains" /> class.
        /// </summary>
        /// <param name="resourceAddress">resourceAddress (required).</param>
        public AssertWorktopContains(ResourceAddress resourceAddress = default(ResourceAddress)) : base("ASSERT_WORKTOP_CONTAINS")
        {
            // to ensure "resourceAddress" is required (not null)
            if (resourceAddress == null)
            {
                throw new InvalidDataException("resourceAddress is a required property for AssertWorktopContains and cannot be null");
            }
            else
            {
                this.ResourceAddress = resourceAddress;
            }

        }

        /// <summary>
        /// Gets or Sets ResourceAddress
        /// </summary>
        [DataMember(Name = "resource_address", EmitDefaultValue = true)]
        public ResourceAddress ResourceAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssertWorktopContains {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  ResourceAddress: ").Append(ResourceAddress).Append("\n");
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
            return this.Equals(input as AssertWorktopContains);
        }

        /// <summary>
        /// Returns true if AssertWorktopContains instances are equal
        /// </summary>
        /// <param name="input">Instance of AssertWorktopContains to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssertWorktopContains input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.ResourceAddress == input.ResourceAddress ||
                    (this.ResourceAddress != null &&
                    this.ResourceAddress.Equals(input.ResourceAddress))
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
                if (this.ResourceAddress != null)
                    hashCode = hashCode * 59 + this.ResourceAddress.GetHashCode();
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
