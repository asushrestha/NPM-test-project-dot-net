using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow.AddMonths(0);

        public string Contact { get; set; }
    }
}