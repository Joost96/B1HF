using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PagePlusOrderPlusCustomer
    {
        public Page Page { get; set; }
        public List<Order> Orders { get; set; }

        public PagePlusOrderPlusCustomer() => Orders = new List<Order>();

        public Customer Customer { get; set; }
    }
}