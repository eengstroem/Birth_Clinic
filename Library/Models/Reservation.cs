using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Rooms;

namespace Library.Models
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
