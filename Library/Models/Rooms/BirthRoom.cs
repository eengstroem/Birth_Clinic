using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.FamilyMembers;

namespace Library.Models.Rooms
{
    public class BirthRoom : Room
    {

        public ICollection<Birth> PlannedBirths { get; set; }

        //optional, can hold mother, father, child and others
        public ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}
