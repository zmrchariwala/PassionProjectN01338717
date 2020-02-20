using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PassionProject_N01338717.Models;
using PassionProject_N01338717.Data;
using PassionProject_N01338717.Models.ViewModel;

namespace PassionProject_N01338717.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
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
        public ActionResult Add(string carmake, string carmodel,string caryear, string carcolor)
        {
            string query= "insert into Cars (Carmake,Carmodel,Caryear,Carcolor) values(@carmake,@carmodel,@caryear,@carcolor)";

            SqlParameter[] sqlparams = new SqlParameter[4]; //0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@carmake",carmake);
            sqlparams[1] = new SqlParameter("@carmodel",carmodel);
            sqlparams[2] = new SqlParameter("@caryear",caryear);
            sqlparams[3] = new SqlParameter("@carcolor",carcolor);
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return View();
        }

        public ActionResult List()
        {
            List<Car> Cars = db.Cars.SqlQuery("select * from Cars").ToList();

            return View(Cars);
        }
        public ActionResult Update(int? id)
        {
            Car car = db.Cars.SqlQuery("select * from Cars where CarID=@carid", new SqlParameter("@carid", id)).FirstOrDefault();
            return View(car);
        }

        [HttpPost]

        public ActionResult Update(int? id, string carmake, string carmodel, string caryear, string carcolor)
        {
            string query = "update Cars set Carmake=@carmake,Carmodel=@carmodel,Caryear=@caryear,Carcolor=@carcolor where CarID=@carid";
            SqlParameter[] sqlparams = new SqlParameter[5]; //0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@carmake", carmake);
            sqlparams[1] = new SqlParameter("@carmodel", carmodel);
            sqlparams[2] = new SqlParameter("@caryear", caryear);
            sqlparams[3] = new SqlParameter("@carcolor", carcolor);
            sqlparams[4] = new SqlParameter("@carid",id);
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

        public ActionResult show(int? id)
        {
            List<Renter> renters = db.Renters.SqlQuery("select * from Renters join Bookings on Renters.RenterID = Bookings.BookingID where Bookings.CarID = @id;",new SqlParameter("@id", id)).ToList();
            Car car = db.Cars.SqlQuery("select * from Cars where CarID=@CarID", new SqlParameter("@CarID", id)).FirstOrDefault();

            CarView carView = new CarView();
            carView.car = car;
            carView.renters = renters;
            return View(carView);
        }
    }
}