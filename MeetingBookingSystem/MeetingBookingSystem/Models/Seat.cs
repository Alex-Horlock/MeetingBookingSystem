/*
 * Seat Booking API
 *
 * zupaTech Seat Booking System
 *
 * OpenAPI spec version: 1.0.0
 * Contact: alexhorlock93@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AlexHorlock.BookingSystem.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Seat : IEquatable<Seat>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [Required]
        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Row
        /// </summary>
        [Required]
        [DataMember(Name="row")]
        public string Row { get; set; }

        /// <summary>
        /// Gets or Sets Column
        /// </summary>
        [Required]
        [DataMember(Name="column")]
        public int? Column { get; set; }

        /// <summary>
        /// Gets or Sets MeetingId
        /// </summary>
        [Required]
        [DataMember(Name="meetingId")]
        public Guid? MeetingId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Seat {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Row: ").Append(Row).Append("\n");
            sb.Append("  Column: ").Append(Column).Append("\n");
            sb.Append("  MeetingId: ").Append(MeetingId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Seat)obj);
        }

        /// <summary>
        /// Returns true if Seat instances are equal
        /// </summary>
        /// <param name="other">Instance of Seat to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Seat other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Row == other.Row ||
                    Row != null &&
                    Row.Equals(other.Row)
                ) && 
                (
                    Column == other.Column ||
                    Column != null &&
                    Column.Equals(other.Column)
                ) && 
                (
                    MeetingId == other.MeetingId ||
                    MeetingId != null &&
                    MeetingId.Equals(other.MeetingId)
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
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Row != null)
                    hashCode = hashCode * 59 + Row.GetHashCode();
                    if (Column != null)
                    hashCode = hashCode * 59 + Column.GetHashCode();
                    if (MeetingId != null)
                    hashCode = hashCode * 59 + MeetingId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Seat left, Seat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Seat left, Seat right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
