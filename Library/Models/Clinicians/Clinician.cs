using Library.Models.Rooms;
using System.Collections.Generic;

namespace Library.Models.Clinicians
{
    public class Clinician
    {
        public int FacultyId { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public Room AssignedRoom { get; set; }
    }
}
