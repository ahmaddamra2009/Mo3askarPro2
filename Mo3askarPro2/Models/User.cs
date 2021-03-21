using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3askarPro2.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter User Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
