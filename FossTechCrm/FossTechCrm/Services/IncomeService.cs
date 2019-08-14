using FossTechCrm.Entities;
using FossTechCrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Services
{
    public class IncomeService
    {

        //For List
        public IEnumerable<Income> GetIncomes()
        {
            var context = new ApplicationDbContext();
            return context.Incomes.ToList();
        }
        //For Edit
        public Income GetIncomesbyId(int id)
        {
            var context = new ApplicationDbContext();
            return context.Incomes.Find(id);
        }

        //For Save
        public bool SaveIncome(Income income)
        {
            var context = new ApplicationDbContext();
            context.Incomes.Add(income);
            return context.SaveChanges() > 0;
        }

        //Update data
        public bool UpdateIncome(Income income)
        {
            var context = new ApplicationDbContext();
            context.Entry(income).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool DeleteIncome(Income income)
        {
            var context = new ApplicationDbContext();
            context.Entry(income).State = System.Data.Entity.EntityState.Deleted;


            return context.SaveChanges() > 0;
        }
    }
}