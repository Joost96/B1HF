using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival.Model
{
    public class ActivityDescription : Description
    {
        [Key, Column(Order = 2), ForeignKey("Activity")]
        public int Activity_ID { get; set; }
        public virtual Activity Activity { get; set; }
    }
}