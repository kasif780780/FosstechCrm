using FossTechCrm.Entities;
using FossTechCrm.Models;
using FossTechCrm.Services;
using FossTechCrm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return Json(new { data = leads }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Action(int? id)
        {
            Lead model = new Lead();

            if (id.HasValue) // we trying to edit this record
            {
                var leadtype = leadService.GetLeadsbyId(id.Value);
                model.LeadID = leadtype.LeadID;
                model.CompanyName = leadtype.CompanyName;
                model.Description = leadtype.Description;
                model.Email = leadtype.Email;
                model.FirstName = leadtype.FirstName;
                model.LeadSource = leadtype.LeadSource;
                model.Phone = leadtype.Phone;
                model.Ratings = leadtype.Ratings;
                model.Status = leadtype.Status;
            }

            //else // we trying create record
            //{

            //}

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(Lead model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            if (model.LeadID > 0)
            {
                var lead = leadService.GetLeadsbyId(model.LeadID);
                lead.CompanyName = model.CompanyName;
                lead.Description = model.Description;
                lead.Email = model.Email;
                lead.FirstName = model.FirstName;
                lead.LeadSource = model.LeadSource;
                lead.Phone = model.Phone;
                lead.Ratings = model.Ratings;
                lead.Status = model.Status;

                result = leadService.UpdateLead(lead);
            }

            else
            {
                Lead lead = new Lead();
                lead.LeadID = model.LeadID;
                lead.CompanyName = model.CompanyName;
                lead.Description = model.Description;
                lead.Email = model.Email;
                lead.FirstName = model.FirstName;
                lead.LeadSource = model.LeadSource;
                lead.Phone = model.Phone;
                lead.Ratings = model.Ratings;
                lead.Status = model.Status;

                result = leadService.SaveLead(lead);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }

            else
            {
                json.Data = new { Success = false, Message = "unable to Add Leads" };
            }
            return json;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Lead model = new Lead();

            var leadtype = leadService.GetLeadsbyId(id);
            model.LeadID = leadtype.LeadID;

             

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(Lead model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            var lead = leadService.GetLeadsbyId(model.LeadID);

            result = leadService.DeleteLead(lead);


            if (result)
            {
                json.Data = new { Success = true };
            }

            else
            {
                json.Data = new { Success = false, Message = "unable to delete Leads" };
            }
            return json;
        }




    }
}