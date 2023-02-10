using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Silk_BLUD_Gest.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<BottlesInFeedings> BottlesInFeedings { get; set; }
        public virtual DbSet<Donations> Donations { get; set; }
        public virtual DbSet<Donors> Donors { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<Feedings> Feedings { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donors>()
                .HasMany(e => e.Donations)
                .WithRequired(e => e.Donors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donors>()
                .HasMany(e => e.Exams)
                .WithRequired(e => e.Donors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donors>()
                .HasMany(e => e.Stock)
                .WithRequired(e => e.Donors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedings>()
                .HasMany(e => e.BottlesInFeedings)
                .WithRequired(e => e.Feedings)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patients>()
                .HasMany(e => e.Feedings)
                .WithRequired(e => e.Patients)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stock>()
                .HasMany(e => e.BottlesInFeedings)
                .WithRequired(e => e.Stock)
                .WillCascadeOnDelete(false);
        }
    }
}
