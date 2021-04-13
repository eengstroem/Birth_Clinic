using Library.Models.Clinicians;
using Library.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Birth
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BirthId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public BirthRoom Room { get; set; }
        public ICollection<Clinician> AssociatedClinicians { get; set; }

        [Required]
        public Child ChildToBeBorn { get; set; }

        [Required]
        public FamilyMember Mother { get; set; }

        //optional
        public FamilyMember Father { get; set; }

        //optional
        public ICollection<FamilyMember> Relatives { get; set; }

    }
}
