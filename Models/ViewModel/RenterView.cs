using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject_N01338717.Models.ViewModel
{
    public class RenterView
    {
        //This works as many many relationship when you need more than one table values
        public List<Car> car { get; set; }
        public Renter renters { get; set; }
    }
}