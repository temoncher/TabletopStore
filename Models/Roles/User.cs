using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopStore.Models
{
    public class User : IdentityUser
    {
        public List<Order> Orders { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
