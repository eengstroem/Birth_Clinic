using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Rooms;
using Library.Models.Clinicians;
using Library.Models.FamilyMembers;

namespace Library.Models
{
    public class BirthClinicDBContext : DbContext
    {

        public BirthClinicDBContext(DbContextOptions<BirthClinicDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Birth> Births { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<BirthRoom> BirthRooms { get; set; }
        public DbSet<RestRoom> RestRooms { get; set; }
        public DbSet<MaternityRoom> MaternityRooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Clinician> Clinicians { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // -- Birth Relationships --

            modelBuilder.Entity<Birth>()
                .HasMany<FamilyMember>(c => c.Relatives)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Birth>()
                .HasMany(c => c.AssociatedClinicians)
                .WithMany(c => c.AssignedBirths)
                .UsingEntity(j => j.ToTable("ClinicianBirthJoins"));

            modelBuilder.Entity<Birth>()
                .HasMany<FamilyMember>(c => c.ChildrenToBeBorn)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Birth>()
                .HasOne(c => c.Mother)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Birth>()
                .HasOne(c => c.Father)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // -- Reservation Relationships --

            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.AssociatedBirth)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.ReservedRoom)
                .WithMany(c => c.CurrentReservations)
                .OnDelete(DeleteBehavior.NoAction);
            



        }
    }
}
