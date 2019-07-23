using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FossTechCrm.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<OrderProduct> Products { get; set; }
    }
}