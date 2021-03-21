using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3askarPro2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Gender { get; set; }
        public string City { get; set; }

    }
}
