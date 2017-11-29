using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public abstract class Description
    {
        [Key, Column(Order = 0)]        
        public Language Language { get; set; }
        [Key, Column(Order = 1)]
        public int Section { get; set; }

        public string Title { get; set; }      
        public string DescriptionText { get; set; }      
        public string ImageUrl { get; set; }

    }
}