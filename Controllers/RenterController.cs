using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassionProject_N01338717.Controllers
{
    public class RenterController : Controller
    {
        // GET: Renter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string renterfirstname, string renterlastname,string renteremail,string renteraddress,string renterdob,string renterusername,string renterpassword)
        {
            Debug.WriteLine("This are my values from add page " + renterfirstname+" " + renterlastname + " " + renteremail + " " + renteraddress + " " + renterdob + " " + renterusername + " " + renterpassword);

            string query = "insert into Renters (RenterFname,RenterLname,RenterEmail,RenterAddress,RenterDOB,RenterUsername,RenterPassowrd) values()";

            return View();
        }

        public ActionResult List()
        {
            return View();
        }
    }
}