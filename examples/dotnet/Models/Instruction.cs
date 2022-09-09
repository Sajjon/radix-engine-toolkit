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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Instruction
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "instruction")]
    [JsonSubtypes.KnownSubType(typeof(AssertWorktopContains), "AssertWorktopContains")]
    [JsonSubtypes.KnownSubType(typeof(AssertWorktopContainsByAmount), "AssertWorktopContainsByAmount")]
    [JsonSubtypes.KnownSubType(typeof(AssertWorktopContainsByIds), "AssertWorktopContainsByIds")]
    [JsonSubtypes.KnownSubType(typeof(CallFunction), "CallFunction")]
    [JsonSubtypes.KnownSubType(typeof(CallMethod), "CallMethod")]
    [JsonSubtypes.KnownSubType(typeof(CallMethodWithAllResources), "CallMethodWithAllResources")]
    [JsonSubtypes.KnownSubType(typeof(ClearAuthZone), "ClearAuthZone")]
    [JsonSubtypes.KnownSubType(typeof(CloneProof), "CloneProof")]
    [JsonSubtypes.KnownSubType(typeof(CreateProofFromAuthZone), "CreateProofFromAuthZone")]
    [JsonSubtypes.KnownSubType(typeof(CreateProofFromAuthZoneByAmount), "CreateProofFromAuthZoneByAmount")]
    [JsonSubtypes.KnownSubType(typeof(CreateProofFromAuthZoneByIds), "CreateProofFromAuthZoneByIds")]
    [JsonSubtypes.KnownSubType(typeof(CreateProofFromBucket), "CreateProofFromBucket")]
    [JsonSubtypes.KnownSubType(typeof(DropAllProofs), "DropAllProofs")]
    [JsonSubtypes.KnownSubType(typeof(DropProof), "DropProof")]
    [JsonSubtypes.KnownSubType(typeof(PopFromAuthZone), "PopFromAuthZone")]
    [JsonSubtypes.KnownSubType(typeof(PublishPackage), "PublishPackage")]
    [JsonSubtypes.KnownSubType(typeof(PushToAuthZone), "PushToAuthZone")]
    [JsonSubtypes.KnownSubType(typeof(ReturnToWorktop), "ReturnToWorktop")]
    [JsonSubtypes.KnownSubType(typeof(TakeFromWorktop), "TakeFromWorktop")]
    [JsonSubtypes.KnownSubType(typeof(TakeFromWorktopByAmount), "TakeFromWorktopByAmount")]
    [JsonSubtypes.KnownSubType(typeof(TakeFromWorktopByIds), "TakeFromWorktopByIds")]
    public partial class Instruction : IEquatable<Instruction>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Instruction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Instruction(string value = default(string))
        {
            this._Instruction = value;
        }

        /// <summary>
        /// Gets or Sets _Instruction
        /// </summary>
        [DataMember(Name = "instruction", EmitDefaultValue = true)]
        public string _Instruction { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Instruction {\n");
            sb.Append("  _Instruction: ").Append(_Instruction).Append("\n");
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
            return this.Equals(input as Instruction);
        }

        /// <summary>
        /// Returns true if Instruction instances are equal
        /// </summary>
        /// <param name="input">Instance of Instruction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Instruction input)
        {
            if (input == null)
                return false;

            return
                (
                    this._Instruction == input._Instruction ||
                    (this._Instruction != null &&
                    this._Instruction.Equals(input._Instruction))
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
                if (this._Instruction != null)
                    hashCode = hashCode * 59 + this._Instruction.GetHashCode();
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
