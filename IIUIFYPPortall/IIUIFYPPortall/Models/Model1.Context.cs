﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIUIFYPPortall.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database1Entities : DbContext
    {
        public Database1Entities()
            : base("name=Database1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Final> Finals { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Panel> Panels { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<SupervisoryDemo> SupervisoryDemoes { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherVerf> TeacherVerfs { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<Verfication> Verfications { get; set; }
        public virtual DbSet<Documentation> Documentations { get; set; }
        public virtual DbSet<InternalExternal> InternalExternals { get; set; }
    }
}
