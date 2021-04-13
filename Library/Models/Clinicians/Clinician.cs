using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Rooms;

namespace Library.Models.Clinicians
{
    public class Clinician
    {
        public int FacultyId { get; set; }

        //public BirthRoom Room { get; set; }

        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public ICollection<Birth> AssignedBirths { get; set; }
        public Room AssignedRoom { get; set; }
    }
}
