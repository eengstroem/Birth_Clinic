using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Rooms;

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

        public DbSet<Clinician> Clinicians { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Debtor>()
                .HasMany(c => c.Debts)
                .WithOne(e => e.Debtor)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasCheckConstraint("CK_Room_RoomType", "RoomType IN ('Maternity Room', 'Birthing Room', 'Resting Room'))");*/
        }
    }
}
