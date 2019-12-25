namespace STEM_backend.Models.DAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class STEMDB : DbContext
    {
        public STEMDB()
            : base("name=STEMDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountPermission> AccountPermissions { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<STEMPlan> STEMPlans { get; set; }
        public virtual DbSet<STEMPlanComment> STEMPlanComments { get; set; }
        public virtual DbSet<STEMReport> STEMReports { get; set; }
        public virtual DbSet<STEMReportComment> STEMReportComments { get; set; }
        public virtual DbSet<STEMStatu> STEMStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.STEMPlanComments)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.ReviewBy);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.STEMReportComments)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.ReviewBy);

            modelBuilder.Entity<STEMStatu>()
                .HasMany(e => e.STEMPlans)
                .WithOptional(e => e.STEMStatu)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<STEMStatu>()
                .HasMany(e => e.STEMReports)
                .WithOptional(e => e.STEMStatu)
                .HasForeignKey(e => e.StatusId);
        }
    }
}
