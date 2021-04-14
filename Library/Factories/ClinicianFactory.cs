using Library.Models.Births;
using Library.Models.Clinicians;
using System.Collections.Generic;

namespace Library.Factory.Clinicians
{
    class ClinicianFactory
    {
        public Clinician createClinician(string FirstName, string LastName, ICollection<Birth> AssignedBirths, ClinicianType Role)
        {
            Clinician c = new();
            c.FirstName = FirstName;
            c.LastName = LastName;
            c.AssignedBirths = AssignedBirths;
            c.Role = Role;

            return c;
        }
    }
}
