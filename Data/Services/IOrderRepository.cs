using TabletopStore.Models.Orders;

namespace TabletopStore.Data.Services
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
