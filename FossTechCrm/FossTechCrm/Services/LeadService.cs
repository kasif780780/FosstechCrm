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
        
        public IEnumerable<Lead> GetLeads()
        {
            var context = new ApplicationDbContext();
           return context.Leads.ToList();
        }

        public bool SaveLead(Lead lead)
        {
            var context = new ApplicationDbContext();
            context.Leads.Add(lead);
            return context.SaveChanges()>0;
        }
    }
}