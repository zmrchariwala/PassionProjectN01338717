using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PassionProject_N01338717.Models;
using PassionProject_N01338717.Data;
using PassionProject_N01338717.Models.ViewModel;

namespace PassionProject_N01338717.Controllers
{
    public class RenterController : Controller
    {
        // GET: Renter
        private CarRenterContext db = new CarRenterContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string renterfirstname, string renterlastname,string renteremail,string renterdob  , string renteraddress, string renterusername,string renterpassword)
        {
            Debug.WriteLine("This are my values from add page " + renterfirstname+" " + renterlastname + " " + renteremail + " " + renteraddress + " " + renterdob + " " + renterusername + " " + renterpassword);

            string query = "insert into Renters (RenterFname,RenterLname,RenterEmail,RenterAddress,RenterDOB,RenterUsername,RenterPassword) values(@Renterfname,@Renterlname,@Renteremail,@Renteraddress,@Renterdob,@Renterusername,@Renterpassword)";
            SqlParameter[] sqlparams = new SqlParameter[7]; 
            sqlparams[0] = new SqlParameter("@Renterfname",renterfirstname);
            sqlparams[1] = new SqlParameter("@Renterlname",renterlastname);
            sqlparams[2] = new SqlParameter("@Renteremail", renteremail);
            sqlparams[3] = new SqlParameter("@Renteraddress", renteraddress);
            sqlparams[4] = new SqlParameter("@Renterdob",renterdob);
            sqlparams[5] = new SqlParameter("@Renterusername",renterusername);
            sqlparams[6] = new SqlParameter("@Renterpassword",renterpassword);
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return View();
        }

        public ActionResult List()
        {
            List<Renter> renters = db.Renters.SqlQuery("select * from Renters").ToList();
 
            return View(renters);
        }

        
        public ActionResult Show(int? id)
        {

            List<Car> cars = db.Cars.SqlQuery("select * from Cars join Bookings on Cars.CarID = Bookings.CarID where Bookings.RenterID = @id;", new SqlParameter("@id", id)).ToList();
            Renter renter = db.Renters.SqlQuery("select * from Renters where RenterID=@RenterID", new SqlParameter("@RenterID", id)).FirstOrDefault();

            RenterView renterview = new RenterView();
            renterview.car = cars;
            renterview.renters = renter;
            return View(renterview);


            //Renter renter = db.Renters.SqlQuery("select * from Renters where RenterID=@RenterID", new SqlParameter("@RenterID", id)).FirstOrDefault();
            //return View(renter);
        }

        [HttpGet]

        public ActionResult Update(int? id)
        {
            Renter renter = db.Renters.SqlQuery("select * from Renters where RenterID=@RenterID", new SqlParameter("@RenterID", id)).FirstOrDefault();
            return View(renter);
        }

        [HttpPost]

        public ActionResult Update(int id,string renterfirstname, string renterlastname, string renteremail, string renterdob, string renteraddress, string renterusername, string renterpassword)
        {
            string query = "update Renters set RenterFname=@Renterfname,RenterLname=@Renterlname,RenterEmail=@Renteremail,RenterAddress=@Renteraddress,RenterDOB=@Renterdob,RenterUsername=@Renterusername,RenterPassword=@Renterpassword where RenterID=@id";
            SqlParameter[] sqlparams = new SqlParameter[8];
            sqlparams[0] = new SqlParameter("@Renterfname", renterfirstname);
            sqlparams[1] = new SqlParameter("@Renterlname", renterlastname);
            sqlparams[2] = new SqlParameter("@Renteremail", renteremail);
            sqlparams[3] = new SqlParameter("@Renteraddress", renteraddress);
            sqlparams[4] = new SqlParameter("@Renterdob", renterdob);
            sqlparams[5] = new SqlParameter("@Renterusername", renterusername);
            sqlparams[6] = new SqlParameter("@Renterpassword", renterpassword);
            sqlparams[7] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);


            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            string query = "delete from Renters where RenterID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");
        }
    }
}