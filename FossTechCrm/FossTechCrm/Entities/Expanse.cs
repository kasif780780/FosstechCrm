using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Entities
{
    public class Expanse
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public string DateOfSpend { get; set; }
        public string Marchant { get; set; }
        public string Category { get; set; }
        public bool Reimbursable { get; set; }
    }
}