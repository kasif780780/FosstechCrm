using FossTechCrm.Entities;
using FossTechCrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Services
{
    public class ProductService
    {
        public IEnumerable<Product> GetProducts()

        {
            var context = new ApplicationDbContext();
            
            return context.Products.ToList();
        }
        //For Edit
        public Product GetProductsbyId(int id)
        {
            var context = new ApplicationDbContext();
            return context.Products.Find(id);
        }

        //For Save
        public bool SaveProduct(Product product)
        {
            var context = new ApplicationDbContext();
            context.Products.Add(product);
            return context.SaveChanges() > 0;
        }

        //Update data
        public bool UpdateProduct(Product product)
        {
            var context = new ApplicationDbContext();
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool DeleteProduct(Product product)
        {
            var context = new ApplicationDbContext();
            context.Entry(product).State = System.Data.Entity.EntityState.Deleted;


            return context.SaveChanges() > 0;
        }
    }
}