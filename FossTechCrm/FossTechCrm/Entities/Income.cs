using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Entities
{
    public class Income
    {
        public int ID { get; set; }
        public string IncomeDate { get; set; }
        public decimal Amount { get; set; }
    }
}