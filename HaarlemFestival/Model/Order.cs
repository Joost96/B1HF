using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
    }
}