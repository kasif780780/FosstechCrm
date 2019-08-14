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
    public class ExpanseController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        ExpanseService incomeService = new ExpanseService();
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }

        //Get all Items to List
        public ActionResult GetExpenses()
        {


            var leads = db.Expanses.ToList();
            return Json(new { data = leads }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Action(int? id)
        {
           Expanse model = new Expanse();

            if (id.HasValue) // we trying to edit this record
            {
                var incometype = incomeService.GetExpensebyId(id.Value);
                model.Id = incometype.Id;
                model.DateOfSpend = incometype.DateOfSpend;
                model.Amount = incometype.Amount;
                model.Category = incometype.Category;
                model.Currency = incometype.Currency;
                model.Marchant = incometype.Marchant;
                model.Purpose = incometype.Purpose;
                model.Reimbursable = incometype.Reimbursable;

            }

            //else // we trying create record
            //{

            //}

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(Expanse model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            if (model.Id > 0)
            {
                var income = incomeService.GetExpensebyId(model.Id);
                income.DateOfSpend = model.DateOfSpend;
                income.Amount = model.Amount;
                income.Category = model.Category;
                income.Marchant = model.Marchant;

                income.Currency = model.Currency;
                income.Purpose = model.Purpose;
                income.Reimbursable = model.Reimbursable;


                result = incomeService.UpdateExpanse(income);
            }

            else
            {
                Expanse income = new Expanse();
                income.Id = model.Id;
                income.DateOfSpend = model.DateOfSpend;
                income.Amount = model.Amount;
                income.Category = model.Category;
                income.Marchant = model.Marchant;

                income.Currency = model.Currency;
                income.Purpose = model.Purpose;
                income.Reimbursable = model.Reimbursable;


                result = incomeService.SaveExpanse(income);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }

            else
            {
                json.Data = new { Success = false, Message = "unable to Add income" };
            }
            return json;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Expanse model = new Expanse();

            var incometype = incomeService.GetExpensebyId(id);
            model.Id = incometype.Id;



            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(Expanse model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            var income = incomeService.GetExpensebyId(model.Id);

            result = incomeService.DeleteExpanse(income);


            if (result)
            {
                json.Data = new { Success = true };
            }

            else
            {
                json.Data = new { Success = false, Message = "unable to delete Income" };
            }
            return json;
        }
    }
}