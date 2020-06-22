using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Models
{
    public class UserModel
    {
        public IdentityUser User { get; set; }
        public bool HasCorrectPassword { get; set; }
    }
}
