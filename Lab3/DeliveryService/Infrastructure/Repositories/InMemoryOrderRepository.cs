using DeliveryService.Domain.Orders;

// хранилище заказов
namespace DeliveryService.Infrastructure.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Order> _orders = new();

        public void Add(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            _orders[order.Id] = order;
        }

        public Order? GetById(Guid id)
        {
            _orders.TryGetValue(id, out var order);
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders.Values.ToList();
        }

        public void Update(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (!_orders.ContainsKey(order.Id))
                throw new KeyNotFoundException("Order not found");

            _orders[order.Id] = order;
        }

        public void Remove(Guid id)
        {
            _orders.Remove(id);
        }
    }
}
