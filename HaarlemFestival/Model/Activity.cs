﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HaarlemFestival.Model
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public EventType Type { get; set; }
        [Required]
        public Location Location { get; set; }
        public List<ActivityDescription> ActivityDescriptions { get; set; }
    }
}