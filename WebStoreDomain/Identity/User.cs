using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Identity
{
    public class User : IdentityUser
    {
        public const string Administrator = "Admin";
        public const string DefaultAdministratorPassword = "pwd";
        public string Description { get; set; }
    }
    public class Role : IdentityRole
    {
        public const string Administrator = "Administrators";
        public const string Users = "Users";
        public string Description { get; set; }
    }
}
