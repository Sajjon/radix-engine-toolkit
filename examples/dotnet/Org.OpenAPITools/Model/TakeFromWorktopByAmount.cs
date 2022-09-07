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


namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// TakeFromWorktopByAmount
    /// </summary>
    [DataContract]
    public partial class TakeFromWorktopByAmount : Instruction,  IEquatable<TakeFromWorktopByAmount>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TakeFromWorktopByAmount" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TakeFromWorktopByAmount() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TakeFromWorktopByAmount" /> class.
        /// </summary>
        /// <param name="resourceAddress">resourceAddress (required).</param>
        /// <param name="amount">amount (required).</param>
        /// <param name="intoBucket">intoBucket (required).</param>
        public TakeFromWorktopByAmount(ResourceAddress resourceAddress = default(ResourceAddress), Decimal amount = default(Decimal), Bucket intoBucket = default(Bucket), string instruction = "TAKE_FROM_WORKTOP_BY_AMOUNT") : base(instruction)
        {
            // to ensure "resourceAddress" is required (not null)
            if (resourceAddress == null)
            {
                throw new InvalidDataException("resourceAddress is a required property for TakeFromWorktopByAmount and cannot be null");
            }
            else
            {
                this.ResourceAddress = resourceAddress;
            }

            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for TakeFromWorktopByAmount and cannot be null");
            }
            else
            {
                this.Amount = amount;
            }

            // to ensure "intoBucket" is required (not null)
            if (intoBucket == null)
            {
                throw new InvalidDataException("intoBucket is a required property for TakeFromWorktopByAmount and cannot be null");
            }
            else
            {
                this.IntoBucket = intoBucket;
            }

        }

        /// <summary>
        /// Gets or Sets ResourceAddress
        /// </summary>
        [DataMember(Name="resource_address", EmitDefaultValue=true)]
        public ResourceAddress ResourceAddress { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=true)]
        public Decimal Amount { get; set; }

        /// <summary>
        /// Gets or Sets IntoBucket
        /// </summary>
        [DataMember(Name="into_bucket", EmitDefaultValue=true)]
        public Bucket IntoBucket { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TakeFromWorktopByAmount {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  ResourceAddress: ").Append(ResourceAddress).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  IntoBucket: ").Append(IntoBucket).Append("\n");
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
            return this.Equals(input as TakeFromWorktopByAmount);
        }

        /// <summary>
        /// Returns true if TakeFromWorktopByAmount instances are equal
        /// </summary>
        /// <param name="input">Instance of TakeFromWorktopByAmount to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TakeFromWorktopByAmount input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.ResourceAddress == input.ResourceAddress ||
                    (this.ResourceAddress != null &&
                    this.ResourceAddress.Equals(input.ResourceAddress))
                ) && base.Equals(input) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && base.Equals(input) && 
                (
                    this.IntoBucket == input.IntoBucket ||
                    (this.IntoBucket != null &&
                    this.IntoBucket.Equals(input.IntoBucket))
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
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.IntoBucket != null)
                    hashCode = hashCode * 59 + this.IntoBucket.GetHashCode();
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
            foreach(var x in base.BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
