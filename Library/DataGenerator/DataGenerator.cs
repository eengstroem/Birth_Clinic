using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.FamilyMembers;
using Library.Models.Births;
using Library.Factory.Clinicians;
using Library.Models.Clinicians;
using Library.Models.Rooms;
using Library.Factory.Rooms;
using Library.Factory.Births;
using Library.Models.Reservations;
using Library.Context;
using Library.Factory.Reservations;
using Library.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Library.DataGenerator
{
    class DataGenerator
    {

        public static void GenerateStaticData(BirthClinicDbContext Context)
        {

            //create midwives
            for (int i = 0; i < 10; i++)
            {
                Context.Clinicians.Add(ClinicianFactory.CreateFakeClinician(ClinicianType.MIDWIFE));
            }

            //create nurses
            for (int i = 0; i < 20; i++)
            {
                Context.Clinicians.Add(ClinicianFactory.CreateFakeClinician(ClinicianType.NURSE));
            }

            //create assistants
            for (int i = 0; i < 20; i++)
            {
                Context.Clinicians.Add(ClinicianFactory.CreateFakeClinician(ClinicianType.HEALTH_ASSISTANT));
            }

            //create Doctors
            for (int i = 0; i < 5; i++)
            {
                Context.Clinicians.Add(ClinicianFactory.CreateFakeClinician(ClinicianType.DOCTOR));
            }

            //create Secretaries
            for (int i = 0; i < 4; i++)
            {
                Context.Clinicians.Add(ClinicianFactory.CreateFakeClinician(ClinicianType.SECRETARY));
            }

            //create Maternity Rooms
            for (int i = 0; i < 22; i++)
            {
                Context.Rooms.Add(RoomFactory.CreateRoom(RoomType.MATERNITY));
            }

            //create Rest Rooms
            for (int i = 0; i < 5; i++)
            {
                Context.Rooms.Add(RoomFactory.CreateRoom(RoomType.REST));
            }

            //create Birth Rooms
            for (int i = 0; i < 15; i++)
            {
                Context.Rooms.Add(RoomFactory.CreateRoom(RoomType.BIRTH));
            }

            //Save before adding births. 
            Context.SaveChanges();
        }

        public static void GenerateData(BirthClinicDbContext Context)
        {
            //Adding 136 Births since there are 5000 births per year (13.6 per day), and we want to simulate 10 days of fake data.
            for (int i = 0; i < 136; i++)
            {
                var B = BirthFactory.CreateFakeBirth();
                var MaternityStartTime = B.BirthDate.AddHours(-132);
                var MaternityEndTime = B.BirthDate.AddHours(-12);

                var RestStartTime = B.BirthDate;
                var RestEndTime = B.BirthDate.AddHours(4);

                var BirthStartTime = B.BirthDate.AddHours(-12);
                var BirthEndTime = B.BirthDate;

                var AvailableMaternityRooms = FindAvailableRooms(Context.Rooms, MaternityStartTime, MaternityEndTime, RoomType.MATERNITY);
                var AvailableBirthRooms = FindAvailableRooms(Context.Rooms, MaternityStartTime, MaternityEndTime, RoomType.BIRTH);
                var AvailableRestRooms = FindAvailableRooms(Context.Rooms, MaternityStartTime, MaternityEndTime, RoomType.REST);

                //Not possible to create a birth at the given time. Find another  hospital.
                if (!AvailableBirthRooms.Any() || !AvailableMaternityRooms.Any() || !AvailableRestRooms.Any())
                {
                    continue;
                }
                    else //There are available rooms of all 3 categories! Nice!
                {
                    //create reservations
                    var MaternityRes = new Reservation
                    {
                        StartTime = MaternityStartTime,
                        EndTime = MaternityEndTime,
                        ReservedRoom = AvailableMaternityRooms.First(),
                        AssociatedBirth = B
                    };

                    var BirthRes = new Reservation
                    {
                        StartTime = BirthStartTime,
                        EndTime = BirthEndTime,
                        ReservedRoom = AvailableBirthRooms.First(),
                        AssociatedBirth = B
                    };

                    var RestRes = new Reservation
                    {
                        StartTime = RestStartTime,
                        EndTime = RestEndTime,
                        ReservedRoom = AvailableRestRooms.First(),
                        AssociatedBirth = B
                    };

                    Context.Reservations.AddRange(new Reservation[]{ MaternityRes, BirthRes, RestRes});
                }
            }
            Context.SaveChanges();
        }

        //TODO switch to single instead of where
        public static IEnumerable<Room> FindAvailableRooms(DbSet<Room> Rooms, DateTime StartTime, DateTime EndTime, RoomType Type)
        {
            return Rooms.Where(room =>

                    //search for conflicts
                    room.CurrentReservations.Where(res =>
                    res.StartTime <= StartTime
                    ||
                    StartTime <= res.EndTime
                    ||
                    res.StartTime <= EndTime
                    ||
                    EndTime <= res.EndTime
                    )//Only returns true if there are no conflicts
                    .Count() == 0 && room.RoomType == Type
                 );
        }
    }


}
