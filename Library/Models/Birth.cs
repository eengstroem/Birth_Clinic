﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Rooms;
using Library.Models.Clinicians;

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
