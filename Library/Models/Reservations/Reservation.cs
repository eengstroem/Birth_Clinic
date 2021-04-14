using Library.Models.Births;
using Library.Models.Rooms;
using System;

namespace Library.Models.Reservations
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get;  set; }
        public Room ReservedRoom { get;  set; }
        public Birth AssociatedBirth { get;  set; }
        public bool IsEndedEarly { get; set; }

    }
}
