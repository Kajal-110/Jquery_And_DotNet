﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KrunalFinalTestEntities : DbContext
    {
        public KrunalFinalTestEntities()
            : base("name=KrunalFinalTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CityTable> CityTable { get; set; }
        public virtual DbSet<CountryTable> CountryTable { get; set; }
        public virtual DbSet<GenderTable> GenderTable { get; set; }
        public virtual DbSet<Hobbies> Hobbies { get; set; }
        public virtual DbSet<StateTable> StateTable { get; set; }
        public virtual DbSet<User_Registration> User_Registration { get; set; }
    }
}
