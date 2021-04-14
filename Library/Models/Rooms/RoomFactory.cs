using System;
using System.Collections.Generic;
using Library.Models.Reservations;
using Library.Models.Clinicians;

namespace Library.Models.Rooms
{
    class RoomFactory
    {
        public Room createRoom(RoomType RoomType, ICollection<Reservation> CurrentReservations)
        {
            Room r = new();
            r.RoomType = RoomType;
            r.CurrentReservations = CurrentReservations;

            return r;
        }

        public Room createRoom(RoomType RoomType, ICollection<Reservation> CurrentReservations, ICollection<Clinician> AssociatedClinicians)
        {
            Room r = new();
            r.RoomType = RoomType;
            r.CurrentReservations = CurrentReservations;
            r.AssociatedClinicians = AssociatedClinicians;

            return r;
        }
    }
}
