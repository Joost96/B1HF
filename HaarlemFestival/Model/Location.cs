using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string  Street { get; set; }
        [Required]
        public int StreetNr { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public decimal Lognitude { get; set; }
        [Required]
        public decimal Latitude { get; set; }
    }
}