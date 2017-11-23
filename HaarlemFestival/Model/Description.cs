using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public abstract class Description
    {
        [Key]
        public Language Language { get; set; }
        [Key]
        public int Section { get; set; }
        
        public string Title { get; set; }
        [Required]
        public string DescriptionText { get; set; }
        
        public string ImageUrl { get; set; }

    }
}