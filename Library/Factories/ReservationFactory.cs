using Library.Models.Births;
using Library.Models.Reservations;
using Library.Models.Rooms;
using System;

namespace Library.Factory.Reservations
{
    public class ReservationFactory
    {
        public Reservation createReservation(DateTime endtime, Room ReservedRoom, Birth AssosiatedBirth)
        {
            Reservation r = new();
            r.StartTime = DateTime.Now;
            r.EndTime = endtime;
            r.ReservedRoom = ReservedRoom;
            r.AssociatedBirth = AssosiatedBirth;
            r.IsEndedEarly = false;

            return r;
        }

        public Reservation createReservation(DateTime starttime, DateTime endtime, Room ReservedRoom, Birth AssosiatedBirth)
        {
            Reservation r = new();
            r.StartTime = starttime;
            r.EndTime = endtime;
            r.ReservedRoom = ReservedRoom;
            r.AssociatedBirth = AssosiatedBirth;
            r.IsEndedEarly = false;

            return r;
        }
    }
}
