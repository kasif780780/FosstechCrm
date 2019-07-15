using FossTechCrm.Entities;
using FossTechCrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Services
{
    public class CustomerService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            var context = new ApplicationDbContext();
            return context.Customers.ToList();
        }

        public Customer GetCustomersbyId(int id)
        {
            var context = new ApplicationDbContext();
            return context.Customers.Find(id);
        }

        //For Save
        public bool SaveCustomer(Customer customer)
        {
            var context = new ApplicationDbContext();
            context.Customers.Add(customer);
            return context.SaveChanges() > 0;
        }

        //Update data
        public bool UpdateCustomer(Customer customer)
        {
            var context = new ApplicationDbContext();
            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool DeleteCustomer(Customer customer)
        {
            var context = new ApplicationDbContext();
            context.Entry(customer).State = System.Data.Entity.EntityState.Deleted;


            return context.SaveChanges() > 0;
        }

    }
}