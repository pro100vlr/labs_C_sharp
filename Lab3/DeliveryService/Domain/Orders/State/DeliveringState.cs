namespace DeliveryService.Domain.Orders.State
{
    public class DeliveringState : IOrderState // состояние когда везем заказ клиенту
    {
        public string Name => "Delivering";

        public void Enter(Order order)
        {
            order.LastStatusChange = DateTime.UtcNow;
        }

        public void MoveToNext(Order order)
        {
            order.SetState(new CompletedState());
        }
    }
}
