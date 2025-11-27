using DeliveryService.Domain.Menu;

namespace DeliveryService.Domain.Menu.Factories
{
    public interface IMenuFactory // интерфейс фабрики меню)
    {
        Dish CreatePizza();
        Dish CreatePasta();
        Dish CreateSalad();
    }
}
