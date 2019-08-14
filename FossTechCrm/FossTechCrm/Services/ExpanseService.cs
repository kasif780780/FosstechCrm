using FossTechCrm.Entities;
using FossTechCrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Services
{
    public class ExpanseService
    {

        //For List
        public IEnumerable<Expanse> GetExpenses()
        {
            var context = new ApplicationDbContext();
            return context.Expanses.ToList();
        }
        //For Edit
        public Expanse GetExpensebyId(int id)
        {
            var context = new ApplicationDbContext();
            return context.Expanses.Find(id);
        }

        //For Save
        public bool SaveExpanse(Expanse expanse)
        {
            var context = new ApplicationDbContext();
            context.Expanses.Add(expanse);
            return context.SaveChanges() > 0;
        }

        //Update data
        public bool UpdateExpanse(Expanse expanse)
        {
            var context = new ApplicationDbContext();
            context.Entry(expanse).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool DeleteExpanse(Expanse expanse)
        {
            var context = new ApplicationDbContext();
            context.Entry(expanse).State = System.Data.Entity.EntityState.Deleted;


            return context.SaveChanges() > 0;
        }
    }
}