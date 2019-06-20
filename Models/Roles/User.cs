using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopStore.Models
{
    public class User : IdentityUser
    {
        private List<Order> Orders { get; set; }
        public DateTime RegisterDate { get; set; }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}
