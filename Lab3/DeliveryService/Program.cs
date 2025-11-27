// пример использования программы без консольного меню (указываем только внутри кода здесь)

using DeliveryService.Domain.Menu;
using DeliveryService.Domain.Menu.Factories;
using DeliveryService.Services;
using DeliveryService.Infrastructure.Repositories;

namespace DeliveryService.App
{
    internal class Program
    {
        static void Main()
        {
            var repository = new InMemoryOrderRepository();
            var orderService = new OrderService(repository);

            IMenuFactory italianMenu = new ItalianMenuFactory();
            IMenuFactory japaneseMenu = new JapaneseMenuFactory();

            var italianDishes = new List<Dish>
            {
                italianMenu.CreatePizza(),
                italianMenu.CreatePasta(),
                italianMenu.CreateSalad()
            };

            var japaneseDishes = new List<Dish>
            {
                japaneseMenu.CreatePizza(),
                japaneseMenu.CreatePasta(),
                japaneseMenu.CreateSalad()
            };

            // создаем заказ
            var order1 = orderService.CreateStandardOrder(italianDishes, "Via Roma 5");
            var order2 = orderService.CreateExpressOrder(japaneseDishes, "Tokyo Street 10");

            Console.WriteLine("--- Созданные заказы ---");
            foreach (var order in orderService.GetAllOrders())
            {
                Console.WriteLine($"Order {order.Id}: {order.State.Name}, Total: {order.CalculateTotal():C}");
            }

            // смена состояний 
            orderService.MoveToNextState(order1.Id); // от готовый к доставке
            orderService.MoveToNextState(order1.Id); // от доставка к выполненому
            orderService.MoveToNextState(order2.Id); // от готовки к доставке

            Console.WriteLine("\n--- После смены состояний ---");
            foreach (var order in orderService.GetAllOrders())
            {
                Console.WriteLine($"Order {order.Id}: {order.State.Name}, Total: {order.CalculateTotal():C}");
            }

            // примеры стратегий
            orderService.SetCostStrategy(order2.Id, new DeliveryService.Domain.Orders.Strategies.DiscountCostStrategy(15));
            Console.WriteLine("\n--- После применения скидки на второй заказ ---");
            var updatedOrder2 = orderService.GetOrder(order2.Id);
            Console.WriteLine($"Order {updatedOrder2.Id}: {updatedOrder2.State.Name}, Total: {updatedOrder2.CalculateTotal():C}");

            Console.WriteLine("\n--- Детали заказа 1 ---");
            var details1 = orderService.GetOrder(order1.Id);
            foreach (var item in details1.Items)
            {
                Console.WriteLine($"- {item.Name} x{item.Quantity} = {item.Total:C}");
            }
        }
    }
}
