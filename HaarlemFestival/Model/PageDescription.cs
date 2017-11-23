using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PageDescription : Description
    {
        [Column(Order = 2), Key, ForeignKey("Page")]
        public string Page_Name { get; set; }
        public virtual Page Page { get; set; }
    }
}