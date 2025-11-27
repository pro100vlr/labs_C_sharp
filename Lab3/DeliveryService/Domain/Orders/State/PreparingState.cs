namespace DeliveryService.Domain.Orders.State
{
    public class PreparingState : IOrderState // готовим - только кухня
    {
        public string Name => "Preparing";

        public void Enter(Order order)
        {
            order.LastStatusChange = DateTime.UtcNow; // метка состояния меняется
        }

        public void MoveToNext(Order order)
        {
            order.SetState(new DeliveringState());
        }
    }
}
