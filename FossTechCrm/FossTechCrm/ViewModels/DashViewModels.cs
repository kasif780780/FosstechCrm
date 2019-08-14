using FossTechCrm.Models;
using FossTechCrm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.ViewModels
{
    public class DashViewModels
    {
        public List<Contact> _contacts { get; set; }
        public List<Customer> _customer { get; set; }
        public List<Order> _order { get; set; }
        public List<Lead> _lead { get; set; }
        public List<Product> _product { get; set; }
    }
}