namespace DeliveryService.Domain.Menu
{
    public class Dish // инф о блюде
    {
        public string Name { get; }
        public decimal Price { get; }

        public Dish(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Dish name cannot be empty");

            if (price < 0)
                throw new ArgumentException("Dish price cannot be negative");

            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price:C}";
        }
    }
}
