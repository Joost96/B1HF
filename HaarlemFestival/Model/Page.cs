using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Page
    {
        public string Name { get; set; }
        public string Titel { get; set; }

        public List<PageDescription> PageDescriptions { get; set; }
    }
}