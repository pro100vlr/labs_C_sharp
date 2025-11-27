using DeliveryService.Domain.Orders.State;
using DeliveryService.Domain.Orders.Strategies;

namespace DeliveryService.Domain.Orders
{
    public class Order // заказ клиента
    {
        public Guid Id { get; }
        public string Address { get; private set; }

        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public DateTime LastStatusChange { get; internal set; } = DateTime.UtcNow;



        public IOrderState State { get; private set; }
        public IOrderCostStrategy CostStrategy { get; private set; }

        public Order(
            Guid id,
            string address,
            IEnumerable<OrderItem> items,
            IOrderState initialState,
            IOrderCostStrategy costStrategy)
        {
            Id = id;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            State = initialState ?? throw new ArgumentNullException(nameof(initialState));
            CostStrategy = costStrategy ?? throw new ArgumentNullException(nameof(costStrategy));

            _items.AddRange(items);
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void SetState(IOrderState newState)
        {
            State = newState ?? throw new ArgumentNullException(nameof(newState));
        }

        public void SetCostStrategy(IOrderCostStrategy strategy)
        {
            CostStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public decimal CalculateTotal()
        {
            return CostStrategy.Calculate(this);
        }

        public void MoveToNextState()
        {
            State.MoveToNext(this);
        }
    }
}
