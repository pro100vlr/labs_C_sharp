namespace DeliveryService.Domain.Orders.State
{
    public class CompletedState : IOrderState // доставлен и завершен
    {
        public string Name => "Completed";

        public void Enter(Order order)
        {
            order.LastStatusChange = DateTime.UtcNow;
        }

        public void MoveToNext(Order order)
        {
            // дальше никуда перейти не можем в состояниях
            throw new InvalidOperationException("Order is already completed.");
        }
    }
}
