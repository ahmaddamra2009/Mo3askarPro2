using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3askarPro2.Models
{
    public class Employee
    {
 
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Enter Employee Name")]
        public string EmployeeName { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter Employee Email")]
        public string Email { get; set; }
     
    }
}
