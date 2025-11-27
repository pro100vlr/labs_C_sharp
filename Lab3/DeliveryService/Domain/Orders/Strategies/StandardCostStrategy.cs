using DeliveryService.Domain.Orders;

namespace DeliveryService.Domain.Orders.Strategies
{
    public class StandardCostStrategy : IOrderCostStrategy
    {
        private const decimal TaxRate = 0.1m;       // налог
        private const decimal DeliveryFee = 5.0m;   // доставка

        public decimal Calculate(Order order)
        {
            var itemsTotal = order.Items.Sum(i => i.Total);
            var total = itemsTotal + (itemsTotal * TaxRate) + DeliveryFee;
            return total;
        }
    }
}
