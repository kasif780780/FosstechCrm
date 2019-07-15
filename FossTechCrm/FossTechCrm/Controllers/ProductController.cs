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
    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        ProductService productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProducts()
        {
            var products = db.Products.ToList();
            return Json(new { data = products }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Action(int? id)
        {
            Product model = new Product();

            if (id.HasValue) // we trying to edit this record
            {
                var leadtype = productService.GetProductsbyId(id.Value);
                model.ProductId = leadtype.ProductId;
                model.Description = leadtype.Description;
                
                model.IsActive = leadtype.IsActive;
                model.IsStock = leadtype.IsStock;
                model.Manufacturer = leadtype.Manufacturer;
                model.ProductCategory = leadtype.ProductCategory;
                model.ProductName = leadtype.ProductName;
                model.SalesEndDate = leadtype.SalesEndDate;
                model.SalesStartDate = leadtype.SalesStartDate;
                model.SupportEndDate = leadtype.SupportEndDate;
                model.SupportStartDate = leadtype.SupportStartDate;
                model.Tax = leadtype.Tax;
                model.Unit = leadtype.Unit;
                model.UnitPrice = leadtype.UnitPrice;
                model.VendorName = leadtype.VendorName;
            }

            //else // we trying create record
            //{

            //}

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(Product model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            if (model.ProductId > 0)
            {
                var lead = productService.GetProductsbyId(model.ProductId);
               


              lead.IsActive = model.IsActive ;
              lead.IsStock = model.IsStock ;
              lead.Manufacturer = model.Manufacturer ;
              lead.ProductCategory = model.ProductCategory;
              lead.ProductName = model.ProductName ;
              lead.SalesEndDate = model.SalesEndDate ;
              lead.SalesStartDate = model.SalesStartDate ;
              lead.SupportEndDate = model.SupportEndDate ;
             lead.SupportStartDate = model.SupportStartDate;
             lead.Tax = model.Tax ;
             lead.Unit= model.Unit;
             lead.UnitPrice = model.UnitPrice;
             lead.VendorName = model.VendorName;

                result = productService.UpdateProduct(lead);
            }

            else
            {
                Product lead = new Product();
                lead.ProductId = model.ProductId;
                lead.IsActive = model.IsActive;
                lead.IsStock = model.IsStock;
                lead.Manufacturer = model.Manufacturer;
                lead.ProductCategory = model.ProductCategory;
                lead.ProductName = model.ProductName;
                lead.SalesEndDate = model.SalesEndDate;
                lead.SalesStartDate = model.SalesStartDate;
                lead.SupportEndDate = model.SupportEndDate;
                lead.SupportStartDate = model.SupportStartDate;
                lead.Tax = model.Tax;
                lead.Unit = model.Unit;
                lead.UnitPrice = model.UnitPrice;
                lead.VendorName = model.VendorName;

                result = productService.SaveProduct(lead);
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

            var leadtype = productService.GetProductsbyId(id);
            model.LeadID = leadtype.ProductId;



            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(Product model)
        {


            JsonResult json = new JsonResult();
            var result = false;
            var lead = productService.GetProductsbyId(model.ProductId);

            result = productService.DeleteProduct(lead);


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