using DeliveryService.Domain.Orders.State;
using DeliveryService.Domain.Orders.Strategies;

// сценарии сборки заказа
namespace DeliveryService.Domain.Orders.Builders
{
    public class OrderDirector
    {
        private readonly IOrderBuilder _builder;

        public OrderDirector(IOrderBuilder builder)
        {
            _builder = builder;
        }

        // стандартный
        public Order BuildStandardOrder(IEnumerable<OrderItem> items, string address)
        {
            return _builder
                .SetAddress(address)
                .SetState(new PreparingState())
                .SetCostStrategy(new StandardCostStrategy())
                .AddItems(items)
                .Build();
        }

        // экспресс-заказ
        public Order BuildExpressOrder(IEnumerable<OrderItem> items, string address)
        {
            return _builder
                .SetAddress(address)
                .SetState(new PreparingState())
                .SetCostStrategy(new FastDeliveryCostStrategy())
                .AddItems(items)
                .Build();
        }
    }

    public static class OrderBuilderExtensions
    {
        public static IOrderBuilder AddItems(this IOrderBuilder builder, IEnumerable<OrderItem> items)
        {
            foreach (var item in items)
            {
                builder.AddItem(item);
            }
            return builder;
        }
    }
}
