using DeliveryService.Domain.Menu;

namespace DeliveryService.Domain.Menu.Factories
{
    public class ItalianMenuFactory : IMenuFactory // пример итальянского меню
    {
        public Dish CreatePizza()
        {
            return new Dish("Пицца Маргаритта", 1200.0m);
        }

        public Dish CreatePasta()
        {
            return new Dish("Паста Карбонара", 635.0m);
        }

        public Dish CreateSalad()
        {
            return new Dish("Греческий салат", 249.0m);
        }
    }
}
