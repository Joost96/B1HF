using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival.Model
{
    public class Customer : Account
    {
       
        public string Country { get; set; }

        public List<Order> Orders { get; set; }

        public Customer(string email, string firstName, string lastName, string password, string Country) : base(email, firstName, lastName, password)
        {
            this.Country = Country;
        }
        public Customer() { }
    }
}