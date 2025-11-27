using DeliveryService.Domain.Orders;

namespace DeliveryService.Domain.Orders.Strategies
{
    public interface IOrderCostStrategy
    {
        decimal Calculate(Order order);
    }
}
