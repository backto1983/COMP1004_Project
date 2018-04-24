namespace Dealership.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UsedVehicleDealership : DbContext
    {
        public UsedVehicleDealership()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>()
                .Property(e => e.make1)
                .IsUnicode(false);

            modelBuilder.Entity<Make>()
                .HasMany(e => e.Vehicles)
                .WithRequired(e => e.Make)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.engineSize)
                .HasPrecision(2, 1);

            modelBuilder.Entity<Model>()
                .Property(e => e.colour)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Vehicles)
                .WithRequired(e => e.Model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.type1)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Models)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.cost)
                .HasPrecision(7, 2);
        }
    }
}
