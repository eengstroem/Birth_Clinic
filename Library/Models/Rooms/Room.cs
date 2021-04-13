using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Clinicians;

namespace Library.Models.Rooms
{
    public class Room
    {
        // This can also be used as the actual room number.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        public Reservation Reservation { get; set; }

        //optional
        public ICollection<Clinician> AssociatedClinicians { get; set; }


    }
}
