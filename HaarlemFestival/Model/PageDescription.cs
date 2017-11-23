using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PageDescription : Description
    {
        [Key]
        public Page Page { get; set; }
    }
}