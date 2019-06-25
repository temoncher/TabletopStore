using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TabletopStore.Models.Orders;

namespace TabletopStore.Models.Roles
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
