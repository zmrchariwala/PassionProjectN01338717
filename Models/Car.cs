using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject_N01338717.Models
{
    public class Car
    {
        [Key]

        public int CarID { get; set; }
        public string Carmake { get; set; }
        public string Carmodel { get; set; }
        public string Caryear { get; set; }
        public string Carcolor { get; set; }
    }
}