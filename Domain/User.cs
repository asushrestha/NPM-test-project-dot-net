using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
         public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Contact { get; set; }
        public string Email { get; set; }
    }
}