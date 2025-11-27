using DeliveryService.Domain.Orders;
using DeliveryService.Domain.Orders.Builders;

namespace DeliveryService.Domain.Orders.Factories // фабрика создания заказа
{
    public interface IOrderFactory
    {
        Order CreateOrder(IEnumerable<OrderItem> items, string address);
    }
}
