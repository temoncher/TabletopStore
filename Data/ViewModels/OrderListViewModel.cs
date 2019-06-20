using System;
using System.Collections.Generic;
using TabletopStore.Models;

namespace TabletopStore.Data.ViewModels
{
    public class OrderListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
