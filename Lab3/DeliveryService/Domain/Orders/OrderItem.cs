namespace DeliveryService.Domain.Orders
{
    public class OrderItem // класс одного блюда (которое добавляем в заказ)
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public OrderItem(string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be > 0");

            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public decimal Total => Price * Quantity;
    }
}
