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
    /// ArrayAllOf
    /// </summary>
    [DataContract]
    public partial class ArrayAllOf :  IEquatable<ArrayAllOf>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets ElementType
        /// </summary>
        [DataMember(Name="element_type", EmitDefaultValue=true)]
        public ValueKind ElementType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayAllOf" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ArrayAllOf() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayAllOf" /> class.
        /// </summary>
        /// <param name="elementType">elementType (required).</param>
        /// <param name="elements">elements (required).</param>
        public ArrayAllOf(ValueKind elementType = default(ValueKind), List<Value> elements = default(List<Value>))
        {
            // to ensure "elementType" is required (not null)
            if (elementType == null)
            {
                throw new InvalidDataException("elementType is a required property for ArrayAllOf and cannot be null");
            }
            else
            {
                this.ElementType = elementType;
            }

            // to ensure "elements" is required (not null)
            if (elements == null)
            {
                throw new InvalidDataException("elements is a required property for ArrayAllOf and cannot be null");
            }
            else
            {
                this.Elements = elements;
            }

        }


        /// <summary>
        /// Gets or Sets Elements
        /// </summary>
        [DataMember(Name="elements", EmitDefaultValue=true)]
        public List<Value> Elements { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ArrayAllOf {\n");
            sb.Append("  ElementType: ").Append(ElementType).Append("\n");
            sb.Append("  Elements: ").Append(Elements).Append("\n");
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
            return this.Equals(input as ArrayAllOf);
        }

        /// <summary>
        /// Returns true if ArrayAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of ArrayAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArrayAllOf input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ElementType == input.ElementType ||
                    (this.ElementType != null &&
                    this.ElementType.Equals(input.ElementType))
                ) && 
                (
                    this.Elements == input.Elements ||
                    this.Elements != null &&
                    input.Elements != null &&
                    this.Elements.SequenceEqual(input.Elements)
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
                if (this.ElementType != null)
                    hashCode = hashCode * 59 + this.ElementType.GetHashCode();
                if (this.Elements != null)
                    hashCode = hashCode * 59 + this.Elements.GetHashCode();
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
