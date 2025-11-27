using DeliveryService.Domain.Menu;

namespace DeliveryService.Domain.Menu.Factories // пример японского меню
{
    public class JapaneseMenuFactory : IMenuFactory
    {
        public Dish CreatePizza()
        {
            return new Dish("Пицца с ананасами", 850.0m);
        }

        public Dish CreatePasta()
        {
            return new Dish("Удон с курицей", 560.0m);
        }

        public Dish CreateSalad()
        {
            return new Dish("Морской салат", 346.0m);
        }
    }
}
