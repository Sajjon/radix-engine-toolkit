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
    /// DecompileTransactionIntentRequest
    /// </summary>
    [DataContract]
    public partial class DecompileTransactionIntentRequest : IEquatable<DecompileTransactionIntentRequest>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets ManifestOutputFormat
        /// </summary>
        [DataMember(Name = "manifest_output_format", EmitDefaultValue = true)]
        public ManifestKind ManifestOutputFormat { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DecompileTransactionIntentRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DecompileTransactionIntentRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DecompileTransactionIntentRequest" /> class.
        /// </summary>
        /// <param name="compiledIntent">compiledIntent (required).</param>
        /// <param name="manifestOutputFormat">manifestOutputFormat (required).</param>
        public DecompileTransactionIntentRequest(string compiledIntent = default(string), ManifestKind manifestOutputFormat = default(ManifestKind))
        {
            // to ensure "compiledIntent" is required (not null)
            if (compiledIntent == null)
            {
                throw new InvalidDataException("compiledIntent is a required property for DecompileTransactionIntentRequest and cannot be null");
            }
            else
            {
                this.CompiledIntent = compiledIntent;
            }

            // to ensure "manifestOutputFormat" is required (not null)
            if (manifestOutputFormat == null)
            {
                throw new InvalidDataException("manifestOutputFormat is a required property for DecompileTransactionIntentRequest and cannot be null");
            }
            else
            {
                this.ManifestOutputFormat = manifestOutputFormat;
            }

        }

        /// <summary>
        /// Gets or Sets CompiledIntent
        /// </summary>
        [DataMember(Name = "compiled_intent", EmitDefaultValue = true)]
        public string CompiledIntent { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DecompileTransactionIntentRequest {\n");
            sb.Append("  CompiledIntent: ").Append(CompiledIntent).Append("\n");
            sb.Append("  ManifestOutputFormat: ").Append(ManifestOutputFormat).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
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
            return this.Equals(input as DecompileTransactionIntentRequest);
        }

        /// <summary>
        /// Returns true if DecompileTransactionIntentRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of DecompileTransactionIntentRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DecompileTransactionIntentRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CompiledIntent == input.CompiledIntent ||
                    (this.CompiledIntent != null &&
                    this.CompiledIntent.Equals(input.CompiledIntent))
                ) &&
                (
                    this.ManifestOutputFormat == input.ManifestOutputFormat ||
                    (this.ManifestOutputFormat != null &&
                    this.ManifestOutputFormat.Equals(input.ManifestOutputFormat))
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
                int hashCode = 41;
                if (this.CompiledIntent != null)
                    hashCode = hashCode * 59 + this.CompiledIntent.GetHashCode();
                if (this.ManifestOutputFormat != null)
                    hashCode = hashCode * 59 + this.ManifestOutputFormat.GetHashCode();
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
            yield break;
        }
    }

}
