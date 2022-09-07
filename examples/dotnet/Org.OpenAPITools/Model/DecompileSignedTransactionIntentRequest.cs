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
    /// DecompileSignedTransactionIntentRequest
    /// </summary>
    [DataContract]
    public partial class DecompileSignedTransactionIntentRequest :  IEquatable<DecompileSignedTransactionIntentRequest>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets ManifestOutputFormat
        /// </summary>
        [DataMember(Name="manifest_output_format", EmitDefaultValue=true)]
        public ManifestKind ManifestOutputFormat { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DecompileSignedTransactionIntentRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DecompileSignedTransactionIntentRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DecompileSignedTransactionIntentRequest" /> class.
        /// </summary>
        /// <param name="compiledSignedIntent">compiledSignedIntent (required).</param>
        /// <param name="manifestOutputFormat">manifestOutputFormat (required).</param>
        public DecompileSignedTransactionIntentRequest(string compiledSignedIntent = default(string), ManifestKind manifestOutputFormat = default(ManifestKind))
        {
            // to ensure "compiledSignedIntent" is required (not null)
            if (compiledSignedIntent == null)
            {
                throw new InvalidDataException("compiledSignedIntent is a required property for DecompileSignedTransactionIntentRequest and cannot be null");
            }
            else
            {
                this.CompiledSignedIntent = compiledSignedIntent;
            }

            // to ensure "manifestOutputFormat" is required (not null)
            if (manifestOutputFormat == null)
            {
                throw new InvalidDataException("manifestOutputFormat is a required property for DecompileSignedTransactionIntentRequest and cannot be null");
            }
            else
            {
                this.ManifestOutputFormat = manifestOutputFormat;
            }

        }

        /// <summary>
        /// Gets or Sets CompiledSignedIntent
        /// </summary>
        [DataMember(Name="compiled_signed_intent", EmitDefaultValue=true)]
        public string CompiledSignedIntent { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DecompileSignedTransactionIntentRequest {\n");
            sb.Append("  CompiledSignedIntent: ").Append(CompiledSignedIntent).Append("\n");
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
            return this.Equals(input as DecompileSignedTransactionIntentRequest);
        }

        /// <summary>
        /// Returns true if DecompileSignedTransactionIntentRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of DecompileSignedTransactionIntentRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DecompileSignedTransactionIntentRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CompiledSignedIntent == input.CompiledSignedIntent ||
                    (this.CompiledSignedIntent != null &&
                    this.CompiledSignedIntent.Equals(input.CompiledSignedIntent))
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
                if (this.CompiledSignedIntent != null)
                    hashCode = hashCode * 59 + this.CompiledSignedIntent.GetHashCode();
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
