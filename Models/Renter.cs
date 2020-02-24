using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject_N01338717.Models
{
    public class Renter
    {
        //Renter class represents tabke in database
        //Whatever fields you create here will create database
        [Key]
        public int RenterID { get; set; }
        public string RenterFname { get; set; }
        public string RenterLname { get; set; }
        public string RenterEmail { get; set; }
        public string RenterAddress { get; set; }
        public string RenterDOB { get; set; }
        public string RenterUsername { get; set; }
        public string RenterPassword { get; set; }
    }
}