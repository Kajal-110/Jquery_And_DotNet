//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Krunal_Final_Test_Model.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Registration
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string PhotoPath { get; set; }
        public string Docpath { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> Hobbies { get; set; }
    
        public virtual CityTable CityTable { get; set; }
        public virtual CountryTable CountryTable { get; set; }
        public virtual GenderTable GenderTable { get; set; }
        public virtual Hobbies Hobbies1 { get; set; }
        public virtual StateTable StateTable { get; set; }
    }
}
