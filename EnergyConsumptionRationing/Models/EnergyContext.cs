namespace EnergyConsumptionRationing.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnergyContext : DbContext
    {
        public EnergyContext()
            : base("name=EnergyContext")
        {
        }

        public virtual DbSet<ConsumedRelease> ConsumedRelease { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<ReleaseProducts> ReleaseProducts { get; set; }
        public virtual DbSet<StandartExpense> StandartExpense { get; set; }
        public virtual DbSet<TypesProduction> TypesProduction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasMany(e => e.ConsumedRelease)
                .WithOptional(e => e.Organization)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.ReleaseProducts)
                .WithOptional(e => e.Organization)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.StandartExpense)
                .WithOptional(e => e.Organization)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TypesProduction>()
                .HasMany(e => e.ConsumedRelease)
                .WithOptional(e => e.TypesProduction)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TypesProduction>()
                .HasMany(e => e.ReleaseProducts)
                .WithOptional(e => e.TypesProduction)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TypesProduction>()
                .HasMany(e => e.StandartExpense)
                .WithOptional(e => e.TypesProduction)
                .WillCascadeOnDelete();
        }
    }
}
