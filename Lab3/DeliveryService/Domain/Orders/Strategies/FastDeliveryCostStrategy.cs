using DeliveryService.Domain.Orders;

// экспресс-доставка - цена
namespace DeliveryService.Domain.Orders.Strategies
{
    public class FastDeliveryCostStrategy : IOrderCostStrategy
    {
        private const decimal TaxRate = 0.1m;
        private const decimal DeliveryFee = 10.0m;  

        public decimal Calculate(Order order)
        {
            var itemsTotal = order.Items.Sum(i => i.Total);
            var total = itemsTotal + (itemsTotal * TaxRate) + DeliveryFee;
            return total;
        }
    }
}
