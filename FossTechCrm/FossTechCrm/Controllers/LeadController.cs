using FossTechCrm.Entities;
using FossTechCrm.Models;
using FossTechCrm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FossTechCrm.Controllers
{
    public class LeadController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        LeadService leadService = new LeadService();
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }

        //Get all Items to List
        public ActionResult GetLeads()
        {


            var leads = db.Leads.ToList();
                return Json (new { data = leads }, JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public ActionResult Action()
        {
            Lead lead = new Lead();
            return PartialView("_Action", lead);
        }

        [HttpPost]
        public JsonResult Action(Lead model)
        {
            JsonResult json = new JsonResult();
            Lead lead = new Lead();
            lead.CompanyName = model.CompanyName;
            lead.Description = model.Description;
            lead.Email = model.Email;
            lead.FirstName = model.FirstName;
            lead.LeadSource = model.LeadSource;
            lead.Phone = model.Phone;
            lead.Ratings = model.Ratings;
            lead.Status = model.Status;

            var result = leadService.SaveLead(lead);
            if(result)
            {
                json.Data = new { Success = true };
            }

            else
            {
                json.Data = new { Success = false, Message = "unable to Add Leads" };
            }
            return json;
        }
    }
}