using Library.Models.Clinicians;
using Library.Models.Reservations;
using Library.Models.Rooms;
using System.Collections.Generic;

namespace Library.Factory.Rooms
{
    class RoomFactory
    {
        public Room CreateRoom(RoomType RoomType, ICollection<Reservation> CurrentReservations)
        {
            Room r = new();
            r.RoomType = RoomType;
            r.CurrentReservations = CurrentReservations;

            return r;
        }

        public Room CreateRoom(RoomType RoomType, ICollection<Reservation> CurrentReservations, ICollection<Clinician> AssociatedClinicians)
        {
            Room r = new();
            r.RoomType = RoomType;
            r.CurrentReservations = CurrentReservations;
            r.AssociatedClinicians = AssociatedClinicians;

            return r;
        }
    }
}
