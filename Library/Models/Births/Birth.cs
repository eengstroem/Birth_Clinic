using Library.Models.Clinicians;
using Library.Models.FamilyMembers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Births
{
    public class Birth
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BirthId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<Clinician> AssociatedClinicians { get; set; }

        [Required]
        public ICollection<FamilyMember> ChildrenToBeBorn { get; set; }

        [Required]
        public FamilyMember Mother { get; set; }

        //optional
        public FamilyMember Father { get; set; }

        //optional
        public ICollection<FamilyMember> Relatives { get; set; }

    }
}
