using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PagePlusOrdersPlusOrderLocation
    {
        public Page Page { get; set; }
        public List<Order> Orders { get; set; }

        public List<OrderLocation> orderLoctions;
    }
}