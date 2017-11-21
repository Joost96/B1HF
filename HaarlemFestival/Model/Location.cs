using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string  Street { get; set; }
        public int StreetNr { get; set; }
        public string ZipCode { get; set; }
        public decimal Lognitude { get; set; }
        public decimal Latitude { get; set; }
    }
}