﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DivingTracker.ServiceLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DivingTrackerEntities : DbContext
    {
        public DivingTrackerEntities()
            : base("name=DivingTrackerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Criterion> Criteria { get; set; }
        public virtual DbSet<CriterionStatus> CriterionStatuses { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ModuleSection> ModuleSections { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<SystemLogin> SystemLogins { get; set; }
        public virtual DbSet<SystemRole> SystemRoles { get; set; }
        public virtual DbSet<UserCriteria> UserCriterias { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserQualification> UserQualifications { get; set; }
    }
}
