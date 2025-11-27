namespace DeliveryService.Domain.Orders.State
{
    public interface IOrderState // интерфейс состояния
    {
        string Name { get; }
        void Enter(Order order);
        void MoveToNext(Order order);
    }
}
