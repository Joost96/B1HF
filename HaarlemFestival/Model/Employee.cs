using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival.Model
{
    
    public class Employee : Account 
    {
        [Required]
        public EmployeeType EmployeeType { get; set; }


    }
}