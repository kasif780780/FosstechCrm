using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Entities
{
    public class Lead
    {
        public int LeadID { get; set; }
        public string FirstName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string LeadSource{ get; set; }
        public string Ratings { get; set; }

    }
}