using Library.Models.Births;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.FamilyMembers
{
    public class Relative : FamilyMember
    {
        [Required]
        public Birth AssociatedBirth { get; set; }
    }
}
