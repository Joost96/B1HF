﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Page
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }

        public List<PageDescription> PageDescriptions { get; set; }
    }
}