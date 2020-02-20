using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject_N01338717.Models.ViewModel
{
    public class CarView
    {
        public Car car { get; set; }
        public List<Renter> renters { get; set; }
    }
}