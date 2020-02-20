using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject_N01338717.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        public int RenterID { get; set; }
        [ForeignKey("RenterID")]
        public virtual Renter Renter{ get; set; }

        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }

    }
}