using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PagePlusOrder
    {
        public Page Page { get; set; }
        public Order Orders { get; set; }

        public decimal TotalOrderPrice { get; set; }
    }
}