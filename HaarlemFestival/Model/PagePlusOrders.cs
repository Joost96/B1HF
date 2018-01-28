using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PagePlusOrders
    {
        public Page Page { get; set; }
        public List<Order> Orders { get; set; }

        public decimal TotalOrderPrice { get; set; }
    }
}