using DeliveryService.Domain.Orders;
using DeliveryService.Domain.Orders.Builders;
using DeliveryService.Domain.Orders.Factories;
using DeliveryService.Domain.Orders.State;
using DeliveryService.Domain.Orders.Strategies;
using DeliveryService.Domain.Menu;
using DeliveryService.Domain.Menu.Factories;
using DeliveryService.Infrastructure.Repositories;

// фасад для работы с заказми - создает, управляет состояниями заказов и меняет стратегию расчета
namespace DeliveryService.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        // стандартный через фабрику
        public Order CreateStandardOrder(IEnumerable<Dish> dishes, string address)
        {
            var items = dishes.Select(d => new OrderItem(d.Name, d.Price, 1)).ToList();

            IOrderFactory factory = new StandardOrderFactory();
            var order = factory.CreateOrder(items, address);

            _repository.Add(order);
            return order;
        }

        // экспресс
        public Order CreateExpressOrder(IEnumerable<Dish> dishes, string address)
        {
            var items = dishes.Select(d => new OrderItem(d.Name, d.Price, 1)).ToList();

            IOrderFactory factory = new ExpressOrderFactory();
            var order = factory.CreateOrder(items, address);

            _repository.Add(order);
            return order;
        }

        // меняем состояние
        public void MoveToNextState(Guid orderId)
        {
            var order = _repository.GetById(orderId);
            if (order == null)
                throw new KeyNotFoundException("Order not found");

            order.MoveToNextState();
        }

        // стоимость
        public void SetCostStrategy(Guid orderId, IOrderCostStrategy strategy)
        {
            var order = _repository.GetById(orderId);
            if (order == null)
                throw new KeyNotFoundException("Order not found");

            order.SetCostStrategy(strategy);
        }

        
        public Order GetOrder(Guid orderId)
        {
            return _repository.GetById(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _repository.GetAll();
        }
    }
}
