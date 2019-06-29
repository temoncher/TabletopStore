using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using TabletopStore.Models.Orders;

namespace TabletopStore.Models.Roles
{
    public class User : IdentityUser
    {
        public List<Order> Orders { get; set; }
        public DateTime RegisterDate { get; set; }

        /*
        public void AddOrder(Order order)
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
            Orders.Add(order);
        }

        public void RemoveOrder(int id)
        {
            var order = Orders.Where(o => o.Id == id).FirstOrDefault();
            order.CurrentState = OrderState.Canceled;
            if (order != null)
            {
                Orders.Remove(order);
            }
        }
        
        public void CompleteOrder(int id)
        {
            var order = Orders.Where(o => o.Id == id).FirstOrDefault();
            order.CurrentState = OrderState.Completed;
        }

        public List<Order> ViewOrders()
        {
            return Orders;
        }
        */
    }
}
