using Library.Models.Rooms;
using System.Collections.Generic;

namespace Library.Models.Clinicians
{
    public enum ClinicianType
    {
        DOCTOR,
        MIDWIFE,
        NURSE,
        HEALTH_ASSISTANT,
        SECRETARY
    }
    public class Clinician
    {
        public int FacultyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Birth> AssignedBirths { get; set; }

        public ClinicianType Role { get; set; }
    }
}
