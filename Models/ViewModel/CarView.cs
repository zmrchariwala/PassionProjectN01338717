using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject_N01338717.Models.ViewModel
{
    public class CarView
    {
        //This works as many many relationship when you need more than one table values
        public Car car { get; set; }
        public List<Renter> renters { get; set; }
    }
}