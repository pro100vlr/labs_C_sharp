using DeliveryService.Domain.Orders;

namespace DeliveryService.Infrastructure.Repositories
{
    public interface IOrderRepository // интерфейс для хранения и доступа к заказам
    {
        void Add(Order order);
        Order? GetById(Guid id);
        IEnumerable<Order> GetAll();
        void Update(Order order);
        void Remove(Guid id);
    }
}
