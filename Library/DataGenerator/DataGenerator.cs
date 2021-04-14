using Library.Context;
using Library.Factory.Births;
using Library.Factory.Clinicians;
using Library.Factory.Rooms;
using Library.Models.Births;
using Library.Models.Clinicians;
using Library.Models.Reservations;
using Library.Models.Rooms;
using Library.Factory.FamilyMembers;
using Library.Models.FamilyMembers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DataGenerator
{
    public class DataGenerator
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
                if (!CreateReservations(Context, B, out List<Reservation> reservations))
                {
                    continue;
                }
                if (!AddClinicians(Context, B, out List<Clinician> Clinicians))
                {
                    continue;
                }

                Context.AddRange(reservations);

                B.AssociatedClinicians = Clinicians;
                B.Mother = AddMother();
                Random rand = new();
                if (rand.Next(1,10) > 1)
                {
                    B.Father = AddFather();
                }
                B.Relatives = AddRelatives();

                B.ChildrenToBeBorn = AddChildrenToBorn();

                Context.Births.Add(B);
            }
            Context.SaveChanges();
        }

        //TODO switch to single instead of where
        public static Room FindAvailableRooms(DbSet<Room> Rooms, DateTime StartTime, DateTime EndTime, RoomType Type)
        {
            return Rooms.First(room =>

                    //search for conflicts
                    room.RoomType == Type && !room.CurrentReservations.Any(res => 
                    (StartTime >= res.StartTime && StartTime <= res.EndTime)
                    ||
                    (EndTime >= res.StartTime && EndTime <= res.EndTime)
                    )//Only returns true if there are no conflicts

                 );
        }

        public static IEnumerable<Clinician> FindAvailableClinicians(DbSet<Clinician> clinicians, Birth Birth, ClinicianType Role)
        {
            int RequiredDelta = 0;
            int AllowedOccurences = 0;

            switch (Role)
            {
                case ClinicianType.DOCTOR:
                    RequiredDelta = 12;
                    AllowedOccurences = 0;
                    break;
                case ClinicianType.HEALTH_ASSISTANT:
                    RequiredDelta = 4;
                    AllowedOccurences = 0;

                    break;
                case ClinicianType.MIDWIFE:
                    RequiredDelta = 120;
                    AllowedOccurences = 8;

                    break;
                case ClinicianType.NURSE:
                    RequiredDelta = 136;
                    AllowedOccurences = 9;

                    break;
                case ClinicianType.SECRETARY:
                    // Secretary only has to check in the birth, so she is freed up immediately, but still associated.
                    AllowedOccurences = 1;

                    break;
            }

            return clinicians.Where(clinician =>

                    //search for conflicts
                    clinician.Role == Role &&
                    clinician.AssignedBirths.Where(b =>
                     (b.BirthDate - Birth.BirthDate).TotalMinutes >= RequiredDelta * 60).Count() == AllowedOccurences

                 );


        }

        public static bool CreateReservations(BirthClinicDbContext Context, Birth Birth, out List<Reservation> reservations)
        {
            var MaternityStartTime = Birth.BirthDate.AddHours(-132);
            var MaternityEndTime = Birth.BirthDate.AddHours(-12);

            var RestStartTime = Birth.BirthDate;
            var RestEndTime = Birth.BirthDate.AddHours(4);

            var BirthStartTime = Birth.BirthDate.AddHours(-12);
            var BirthEndTime = Birth.BirthDate;

            var AvailableMaternityRoom = FindAvailableRooms(Context.Rooms, MaternityStartTime, MaternityEndTime, RoomType.MATERNITY);
            var AvailableBirthRoom = FindAvailableRooms(Context.Rooms, MaternityStartTime, MaternityEndTime, RoomType.BIRTH);
            var AvailableRestRoom = FindAvailableRooms(Context.Rooms, MaternityStartTime, MaternityEndTime, RoomType.REST);

            //Not possible to create a birth at the given time. Find another  hospital.
            if (AvailableBirthRoom == null || AvailableMaternityRoom == null || AvailableRestRoom == null)
            {
                reservations = null;
                return false;
            }
            else //There are available rooms of all 3 categories! Nice!
            {
                //create reservations
                var MaternityRes = new Reservation
                {
                    StartTime = MaternityStartTime,
                    EndTime = MaternityEndTime,
                    ReservedRoom = AvailableMaternityRoom,
                    AssociatedBirth = Birth
                };

                var BirthRes = new Reservation
                {
                    StartTime = BirthStartTime,
                    EndTime = BirthEndTime,
                    ReservedRoom = AvailableBirthRoom,
                    AssociatedBirth = Birth
                };

                var RestRes = new Reservation
                {
                    StartTime = RestStartTime,
                    EndTime = RestEndTime,
                    ReservedRoom = AvailableRestRoom,
                    AssociatedBirth = Birth
                };

                reservations = new List<Reservation> { MaternityRes, BirthRes, RestRes };
                return true;
            }
        }

        public static bool AddClinicians(BirthClinicDbContext Context, Birth Birth, out List<Clinician> Clinicians)
        {

            Random Rand = new();
            IEnumerable<Clinician> FoundClinicians;
            Clinicians = new();

            // Finds available Doctor and inserts one random available Doctor into output List.
            FoundClinicians = FindAvailableClinicians(Context.Clinicians, Birth, ClinicianType.DOCTOR);
            if (!FoundClinicians.Any())
            {
                return false;
            }
            Clinicians.Add(FoundClinicians.ElementAt(Rand.Next(0, FoundClinicians.Count())));


            // Finds available Midwife and inserts one random available Midwife into output List.
            FoundClinicians = FindAvailableClinicians(Context.Clinicians, Birth, ClinicianType.MIDWIFE);
            if (!FoundClinicians.Any())
            {
                return false;
            }
            Clinicians.Add(FoundClinicians.ElementAt(Rand.Next(0, FoundClinicians.Count())));


            // Finds available Nurse and inserts two random available Nurse into output List.
            FoundClinicians = FindAvailableClinicians(Context.Clinicians, Birth, ClinicianType.NURSE);

            if (FoundClinicians.Count() < 2)
            {
                return false;
            }
            int randresult = Rand.Next(0, FoundClinicians.Count());

            if (randresult == FoundClinicians.Count())
            {
                randresult--;
            }

            Clinicians.Add(FoundClinicians.ElementAt(randresult));
            Clinicians.Add(FoundClinicians.ElementAt(randresult++));


            // Finds available Assistant and inserts two random available Assistant into output List.
            FoundClinicians = FindAvailableClinicians(Context.Clinicians, Birth, ClinicianType.HEALTH_ASSISTANT);
            if (!FoundClinicians.Any())
            {
                return false;
            }
            Clinicians.Add(FoundClinicians.ElementAt(Rand.Next(0, FoundClinicians.Count())));


            // Finds available Secretary and inserts two random available Secretary into output List.
            FoundClinicians = FindAvailableClinicians(Context.Clinicians, Birth, ClinicianType.SECRETARY);
            if (!FoundClinicians.Any())
            {
                return false;
            }
            Clinicians.Add(FoundClinicians.ElementAt(Rand.Next(0, FoundClinicians.Count())));

            return true;
        }

        public static FamilyMember AddMother()
        {
            return FamilyMemberFactory.CreateFakeFamilyMember(FamilyMemberType.MOTHER);
        }

        public static FamilyMember AddFather()
        {
            return FamilyMemberFactory.CreateFakeFamilyMember(FamilyMemberType.FATHER);
        }

        public static List<FamilyMember> AddRelatives()
        {
            Random rand = new();
            List<FamilyMember> FamilyMembers = new();
            for (int i = rand.Next(1,10); i == 0; i--)
            {
                FamilyMembers.Add(FamilyMemberFactory.CreateFakeFamilyMember(FamilyMemberType.RELATIVE));
            }
            return FamilyMembers;
        }

        public static List<FamilyMember> AddChildrenToBorn()
        {
            Random rand = new();
            double weight = rand.NextDouble();

            List<FamilyMember> Children = new();

            Children.Add(FamilyMemberFactory.CreateFakeFamilyMember(FamilyMemberType.CHILD));
            if (weight > 0.75)
            {
                Children.Add(FamilyMemberFactory.CreateFakeFamilyMember(FamilyMemberType.CHILD));
                if(weight > 0.85)
                {
                    Children.Add(FamilyMemberFactory.CreateFakeFamilyMember(FamilyMemberType.CHILD));
                    if (weight > 0.95)
                    {
                        Children.Add(FamilyMemberFactory.CreateFakeFamilyMember(FamilyMemberType.CHILD));
                    }
                }
            }
            return Children;
        }
    }
}
