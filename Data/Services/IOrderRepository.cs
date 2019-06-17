using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;

namespace TabletopStore.Data.Services
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
