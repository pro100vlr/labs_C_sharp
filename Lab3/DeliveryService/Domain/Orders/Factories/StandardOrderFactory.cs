using DeliveryService.Domain.Orders.Builders;
using DeliveryService.Domain.Orders.State;
using DeliveryService.Domain.Orders.Strategies;

namespace DeliveryService.Domain.Orders.Factories // фабрика создания стандартного заказа
{
    public class StandardOrderFactory : IOrderFactory
    {
        public Order CreateOrder(IEnumerable<OrderItem> items, string address)
        {
            var builder = new OrderBuilder();
            var director = new OrderDirector(builder);

            return director.BuildStandardOrder(items, address); // создает по шагово из Builders/OrderDirector.cs

        }
    }
}
