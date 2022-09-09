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
    /// UnexpectedContents
    /// </summary>
    [DataContract]
    public partial class UnexpectedContents : ErrorResponse, IEquatable<UnexpectedContents>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Kind
        /// </summary>
        [DataMember(Name = "kind", EmitDefaultValue = true)]
        public ValueKind Kind { get; set; }
        /// <summary>
        /// Gets or Sets Found
        /// </summary>
        [DataMember(Name = "found", EmitDefaultValue = true)]
        public ValueKind Found { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedContents" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UnexpectedContents() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedContents" /> class.
        /// </summary>
        /// <param name="kind">kind (required).</param>
        /// <param name="expected">expected (required).</param>
        /// <param name="found">found (required).</param>
        public UnexpectedContents(ValueKind kind = default(ValueKind), List<ValueKind> expected = default(List<ValueKind>), ValueKind found = default(ValueKind)) : base("UnexpectedContents")
        {
            // to ensure "kind" is required (not null)
            if (kind == null)
            {
                throw new InvalidDataException("kind is a required property for UnexpectedContents and cannot be null");
            }
            else
            {
                this.Kind = kind;
            }

            // to ensure "expected" is required (not null)
            if (expected == null)
            {
                throw new InvalidDataException("expected is a required property for UnexpectedContents and cannot be null");
            }
            else
            {
                this.Expected = expected;
            }

            // to ensure "found" is required (not null)
            if (found == null)
            {
                throw new InvalidDataException("found is a required property for UnexpectedContents and cannot be null");
            }
            else
            {
                this.Found = found;
            }

        }


        /// <summary>
        /// Gets or Sets Expected
        /// </summary>
        [DataMember(Name = "expected", EmitDefaultValue = true)]
        public List<ValueKind> Expected { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UnexpectedContents {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Kind: ").Append(Kind).Append("\n");
            sb.Append("  Expected: ").Append(Expected).Append("\n");
            sb.Append("  Found: ").Append(Found).Append("\n");
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
            return this.Equals(input as UnexpectedContents);
        }

        /// <summary>
        /// Returns true if UnexpectedContents instances are equal
        /// </summary>
        /// <param name="input">Instance of UnexpectedContents to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UnexpectedContents input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.Kind == input.Kind ||
                    (this.Kind != null &&
                    this.Kind.Equals(input.Kind))
                ) && base.Equals(input) &&
                (
                    this.Expected == input.Expected ||
                    this.Expected != null &&
                    input.Expected != null &&
                    this.Expected.SequenceEqual(input.Expected)
                ) && base.Equals(input) &&
                (
                    this.Found == input.Found ||
                    (this.Found != null &&
                    this.Found.Equals(input.Found))
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
                if (this.Kind != null)
                    hashCode = hashCode * 59 + this.Kind.GetHashCode();
                if (this.Expected != null)
                    hashCode = hashCode * 59 + this.Expected.GetHashCode();
                if (this.Found != null)
                    hashCode = hashCode * 59 + this.Found.GetHashCode();
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
