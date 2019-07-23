using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FossTechCrm.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string VendorName { get; set; }
        public string HSNCode { get; set; }
        public string Manufacturer { get; set; }
        [DataType(DataType.Date)]
        public string SalesEndDate { get; set; }
        [DataType(DataType.Date)]
        public string SalesStartDate { get; set; }

        [DataType(DataType.Date)]
        public string SupportStartDate { get; set; }
        [DataType(DataType.Date)]
        public string SupportEndDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Tax { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public bool IsStock { get; set; }
        public bool IsActive { get; set; }

    }
}