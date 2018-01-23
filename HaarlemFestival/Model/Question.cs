using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Spreker { get; set; }
        [Required]
        public string Message { get; set; }
    }
}