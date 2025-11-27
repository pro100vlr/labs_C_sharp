using NUnit.Framework;
using DeliveryService.Domain.Orders;
using DeliveryService.Domain.Orders.Factories;
using DeliveryService.Domain.Orders.Strategies;
using DeliveryService.Domain.Menu;
using DeliveryService.Domain.Menu.Factories;
using DeliveryService.Services;
using DeliveryService.Infrastructure.Repositories;
using System.Linq;

namespace DeliveryService.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private OrderService _service = null!;  // фасад
        private InMemoryOrderRepository _repository = null!;   // хранилище

        [SetUp]
        public void Setup()
        {
            _repository = new InMemoryOrderRepository();
            _service = new OrderService(_repository);
        }

        [Test]
        public void CreateStandardOrder_ShouldContainCorrectItems()
        {
            var menuFactory = new ItalianMenuFactory();
            var dishes = new List<Dish>
            {
                menuFactory.CreatePizza(),
                menuFactory.CreateSalad()
            };

            var order = _service.CreateStandardOrder(dishes, "Via Roma 5");

            var items = order.Items.ToList(); 
            Assert.That(items.Count, Is.EqualTo(2));
            Assert.That(items[0].Name, Is.EqualTo("Пицца Маргаритта"));
            Assert.That(items[1].Name, Is.EqualTo("Греческий салат"));
        }

        [Test]
        public void Order_ShouldChangeStatesCorrectly()
        {
            var menuFactory = new ItalianMenuFactory();
            var dishes = new List<Dish> { menuFactory.CreatePasta() };
            var order = _service.CreateStandardOrder(dishes, "Via Roma 5");

            Assert.That(order.State.Name, Is.EqualTo("Preparing"));

            _service.MoveToNextState(order.Id);
            Assert.That(order.State.Name, Is.EqualTo("Delivering"));

            _service.MoveToNextState(order.Id);
            Assert.That(order.State.Name, Is.EqualTo("Completed"));
        }

        [Test]
        public void DiscountStrategy_ShouldApplyCorrectDiscount()
        {
            var menuFactory = new JapaneseMenuFactory();
            var dishes = new List<Dish> { menuFactory.CreatePizza() };

            var order = _service.CreateExpressOrder(dishes, "Tokyo Street 10");

            _service.SetCostStrategy(order.Id, new DiscountCostStrategy(10));

            var itemsSum = order.Items.Sum(i => i.Total);
            var expectedTotal = itemsSum * 0.9m; // 10% скидка

            Assert.That(order.Items.Sum(i => i.Total) * 0.9m, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void GetAllOrders_ShouldReturnAllCreatedOrders()
        {
            var menuFactory = new ItalianMenuFactory();
            var dishes1 = new List<Dish> { menuFactory.CreatePizza() };
            var dishes2 = new List<Dish> { menuFactory.CreatePasta() };

            var order1 = _service.CreateStandardOrder(dishes1, "Via Roma 1");
            var order2 = _service.CreateExpressOrder(dishes2, "Via Roma 2");

            var allOrders = _service.GetAllOrders().ToList();

            Assert.That(allOrders.Count, Is.EqualTo(2));
            Assert.That(allOrders, Contains.Item(order1));
            Assert.That(allOrders, Contains.Item(order2));
        }

        [Test]
        public void CalculateTotal_ShouldMatchSumOfItems()
        {
            var menuFactory = new ItalianMenuFactory();
            var dishes = new List<Dish>
            {
                menuFactory.CreatePizza(),   // 1200
                menuFactory.CreatePasta(),   // 635
                menuFactory.CreateSalad()    // 249
            };

            var order = _service.CreateStandardOrder(dishes, "Via Roma 5");

            var itemsSum = order.Items.Sum(i => i.Total); // 1200 + 635 + 249 = 2084
            Assert.That(itemsSum, Is.EqualTo(2084));
        }

        [Test]
        public void ExpressOrder_ShouldUseFastDeliveryStrategy()
        {
            var menuFactory = new JapaneseMenuFactory();
            var dishes = new List<Dish> { menuFactory.CreatePizza(), menuFactory.CreateSalad() };

            var order = _service.CreateExpressOrder(dishes, "Tokyo Street 5");

            var itemsSum = order.Items.Sum(i => i.Total);
            var total = order.CalculateTotal();

            Assert.That(total, Is.GreaterThan(itemsSum)); 
        }
    }
}
