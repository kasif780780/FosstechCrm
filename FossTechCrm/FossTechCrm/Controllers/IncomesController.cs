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
    public class IncomesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        IncomeService incomeService = new IncomeService();
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }

        //Get all Items to List
        public ActionResult GetIncomes()
        {


            var leads = db.Incomes.ToList();
            return Json(new { data = leads }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Action(int? id)
        {
            Income model = new Income();

            if (id.HasValue) // we trying to edit this record
            {
                var incometype = incomeService.GetIncomesbyId(id.Value);
                model.ID = incometype.ID;
                model.IncomeDate = incometype.IncomeDate;
                model.Amount = incometype.Amount;

            }

            //else // we trying create record
            //{

            //}

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(Income model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var income = incomeService.GetIncomesbyId(model.ID);
                income.IncomeDate = model.IncomeDate;
                income.Amount = model.Amount;
              
               
                result = incomeService.UpdateIncome(income);
            }

            else
            {
                Income income = new Income();
                income.ID = model.ID;
                income.IncomeDate = model.IncomeDate;
                income.Amount = model.Amount;
               

                result = incomeService.SaveIncome(income);
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
            Income model = new Income();

            var incometype = incomeService.GetIncomesbyId(id);
            model.ID = incometype.ID;



            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(Income model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            var income = incomeService.GetIncomesbyId(model.ID);

            result = incomeService.DeleteIncome(income);


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