using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival.Model
{
    public class ActivityDescription : Description
    {
        [Key]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}