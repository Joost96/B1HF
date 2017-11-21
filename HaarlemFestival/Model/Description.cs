using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public abstract class Description
    {
        public string PageName { get; set; }
        public int ActivityId { get; set; }
        public int Section { get; set; }
        public Language language { get; set; }
    }
}