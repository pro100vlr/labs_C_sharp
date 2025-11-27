using DeliveryService.Domain.Orders.State;
using DeliveryService.Domain.Orders.Strategies;

// вызываем конструкторы с параметрами 
namespace DeliveryService.Domain.Orders.Builders
{
    public class OrderBuilder : IOrderBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string? _address;
        private readonly List<OrderItem> _items = new();
        private IOrderState? _state;
        private IOrderCostStrategy? _strategy;

        public IOrderBuilder SetAddress(string address)
        {
            _address = address;
            return this;
        }

        public IOrderBuilder AddItem(OrderItem item)
        {
            _items.Add(item);
            return this;
        }

        public IOrderBuilder SetState(IOrderState state)
        {
            _state = state;
            return this;
        }

        public IOrderBuilder SetCostStrategy(IOrderCostStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        public Order Build()
        {
            if (string.IsNullOrWhiteSpace(_address))
                throw new InvalidOperationException("Address must be set");

            if (!_items.Any())
                throw new InvalidOperationException("Order must have at least one item");

            if (_state == null)
                throw new InvalidOperationException("State must be set");

            if (_strategy == null)
                throw new InvalidOperationException("CostStrategy must be set");

            return new Order(
                _id,
                _address,
                _items,
                _state,
                _strategy
            );
        }
    }
}
