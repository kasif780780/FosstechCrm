using FossTechCrm.Entities;
using FossTechCrm.Models;
using FossTechCrm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FossTechCrm.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var dbl = new DashViewModels();
            var contact = (from c in db.Contacts select c).ToList();
            var product = (from p in db.Products select p).ToList();
            var order = (from o in db.Orders select o).ToList();
            var customer = (from cu in db.Customers select cu).ToList();
            var lead = (from l in db.Leads select l).ToList();
           
            var model = new DashViewModels
            {
                _contacts = contact,
                _product = product,
                _order = order,
                _customer = customer,
                _lead = lead
                
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Leads()
        {
            return View();
        }
        public ActionResult getdata()
        {
            List<Lead> data = db.Leads.ToList<Lead>();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

      
    }
}