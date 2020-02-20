using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace PassionProject_N01338717.Data
{
    public class CarRenterContext:DbContext
    {
        public CarRenterContext() : base("name=CarRenterContext")
        {
        }

        public System.Data.Entity.DbSet<PassionProject_N01338717.Models.Renter> Renters { get; set; }
        public System.Data.Entity.DbSet<PassionProject_N01338717.Models.Car> Cars { get; set; }
        public System.Data.Entity.DbSet<PassionProject_N01338717.Models.Booking> Bookings { get; set; }
    }
}