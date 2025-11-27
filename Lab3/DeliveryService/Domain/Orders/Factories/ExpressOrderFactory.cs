using DeliveryService.Domain.Orders.Builders;
using DeliveryService.Domain.Orders.State;
using DeliveryService.Domain.Orders.Strategies;

namespace DeliveryService.Domain.Orders.Factories // фабрика экспресс-заказа
{
    public class ExpressOrderFactory : IOrderFactory
    {
        public Order CreateOrder(IEnumerable<OrderItem> items, string address)
        {
            var builder = new OrderBuilder();
            var director = new OrderDirector(builder);

            return director.BuildExpressOrder(items, address);
        }
    }
}
