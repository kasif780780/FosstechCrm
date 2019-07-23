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
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        CustomerService customerService = new CustomerService();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomers()
        {
            var customers = db.Customers.ToList();
            return Json(new { data = customers }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Action(int? id)
        {
            Customer model = new Customer();

            if (id.HasValue) // we trying to edit this record
            {
                var leadtype = customerService.GetCustomersbyId(id.Value);

                model.Id = leadtype.Id;
                model.Company = leadtype.Company;
                model.Description = leadtype.Description;
                model.Email = leadtype.Email;
                model.FirstName = leadtype.FirstName;
                model.LastName = leadtype.LastName;
                model.Phone = leadtype.Phone;
                model.State = leadtype.State;
                model.City = leadtype.City;
                model.Country = leadtype.Country;
                model.Street = leadtype.Street;
                model.Zip = leadtype.Zip;
            }

            //else // we trying create record
            //{

            //}

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(Customer model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            if (model.Id > 0)
            {
                var lead = customerService.GetCustomersbyId(model.Id);

                lead.Company = model.Company;
                lead.Description = model.Description;
                lead.Email = model.Email;
                lead.FirstName = model.FirstName;
                lead.LastName = model.LastName;
                lead.Phone = model.Phone;
                lead.State = model.State;
                lead.City = model.City;
                lead.Country = model.Country;
                lead.Street = model.Street;
                lead.Zip = model.Zip;
                
                result = customerService.UpdateCustomer(lead);
            }

            else
            {
                Customer customer = new Customer();

                customer.Id = model.Id;
                customer.Date = model.Date;
                customer.Company = model.Company;
                customer.Description = model.Description;
                customer.Email = model.Email;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Phone = model.Phone;
                customer.State = model.State;
                customer.City = model.City;
                customer.Country = model.Country;
                customer.Street = model.Street;
                customer.Zip = model.Zip;

                result = customerService.SaveCustomer(customer);
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
            Customer model = new Customer();

            var leadtype = customerService.GetCustomersbyId(id);
            model.Id = leadtype.Id;



            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(Customer model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            var lead = customerService.GetCustomersbyId(model.Id);

            result = customerService.DeleteCustomer(lead);


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