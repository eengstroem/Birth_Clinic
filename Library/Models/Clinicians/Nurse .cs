using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Clinicians
{
    public class Nurse : Clinician
    {
        public ICollection<Birth> AssignedBirths { get; set; }
    }
}
