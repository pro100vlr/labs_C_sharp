using DeliveryService.Domain.Orders;

// пример ценообразоваия со скидкой
namespace DeliveryService.Domain.Orders.Strategies
{
    public class DiscountCostStrategy : IOrderCostStrategy
    {
        private readonly decimal _discountPercentage; 
        private const decimal TaxRate = 0.1m;
        private const decimal DeliveryFee = 5.0m;

        public DiscountCostStrategy(decimal discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }

        public decimal Calculate(Order order)
        {
            var itemsTotal = order.Items.Sum(i => i.Total);
            var discounted = itemsTotal * (1 - _discountPercentage / 100);
            var total = discounted + (discounted * TaxRate) + DeliveryFee;
            return total;
        }
    }
}
