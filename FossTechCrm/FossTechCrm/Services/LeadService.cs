using FossTechCrm.Entities;
using FossTechCrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Services
{
    public class LeadService
    {
        
        //For List
        public IEnumerable<Lead> GetLeads()
        {
            var context = new ApplicationDbContext();
           return context.Leads.ToList();
        }
        //For Edit
        public Lead GetLeadsbyId (int id)
        {
            var context = new ApplicationDbContext();
            return context.Leads.Find(id);
        }

        //For Save
        public bool SaveLead(Lead lead)
        {
            var context = new ApplicationDbContext();
            context.Leads.Add(lead);
            return context.SaveChanges()>0;
        }

        //Update data
        public bool UpdateLead(Lead lead)
        {
            var context = new ApplicationDbContext();
            context.Entry(lead).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool DeleteLead(Lead lead)
        {
            var context = new ApplicationDbContext();
            context.Entry(lead).State = System.Data.Entity.EntityState.Deleted;
            
       
            return context.SaveChanges() > 0;
        }
    }
}