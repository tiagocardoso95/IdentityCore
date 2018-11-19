using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Models
{
    public class User : IdentityUser
    {
        public User() : base()  { }

        //public int UserId { get; set; }

        public string Name { get; set; }
        override
        public string Email{ get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistedDate { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
    }
}
