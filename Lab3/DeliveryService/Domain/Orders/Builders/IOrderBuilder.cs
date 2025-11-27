using DeliveryService.Domain.Orders;
using DeliveryService.Domain.Orders.State;
using DeliveryService.Domain.Orders.Strategies;

namespace DeliveryService.Domain.Orders.Builders // интерфейс создания
{
    public interface IOrderBuilder
    {
        IOrderBuilder SetAddress(string address);
        IOrderBuilder AddItem(OrderItem item);
        IOrderBuilder SetState(IOrderState state);
        IOrderBuilder SetCostStrategy(IOrderCostStrategy strategy);

        Order Build();
    }
}
