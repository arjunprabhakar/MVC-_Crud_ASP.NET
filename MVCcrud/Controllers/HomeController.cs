using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MVCcrud.Models;

namespace MVCcrud.Controllers
{
    public class HomeController : Controller
    {
        database_Access_layer.db dblayer=new database_Access_layer.db();
        public ActionResult Show_data()
        {
            DataSet ds=dblayer.Show_data();
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        public ActionResult Add_record()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult Add_record(FormCollection fc)
        {
           Employee emp=new Employee();
            emp.Empname = fc["Empname"];
            emp.Email = fc["Email"];
            emp.Salary = fc["Salary"];
            dblayer.Add_record(emp);
            TempData["msg"] = "Inserted";

            return RedirectToAction("Show_data");

        }

        public ActionResult Update_record(int Empid)
        {
            DataSet ds=dblayer.Show_recod_byid(Empid);
            ViewBag.emprecord = ds.Tables[0];

            return View();
        }

        [HttpPost]
        public ActionResult Update_record(int Empid,FormCollection fc)
        {
            Employee emp = new Employee();
            emp.Empid=Empid;
            emp.Empname = fc["Empname"];
            emp.Email = fc["Email"];
            emp.Salary = fc["Salary"];
            dblayer.Update_record(emp);
            TempData["msg"] = "Updated";

            return RedirectToAction("Show_data");

        }


        public ActionResult Delete_record(int Empid)
        {
            dblayer.delete_record(Empid);
            TempData["msg"] = "Deleted";
            return RedirectToAction("Show_data");

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}