//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamQuestion.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> Date_of_birth { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Profile_photo { get; set; }
        public string Attachment { get; set; }
        public string Gender { get; set; }
        public string Hobbies { get; set; }
        public Nullable<bool> IsIntrestedInDanching { get; set; }
        public Nullable<bool> IsIntrestedInReading { get; set; }
        public Nullable<bool> IsIntrestedInCooking { get; set; }
    
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
