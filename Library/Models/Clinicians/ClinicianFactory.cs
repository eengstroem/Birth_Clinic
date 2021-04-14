using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Births;

namespace Library.Models.Clinicians
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
