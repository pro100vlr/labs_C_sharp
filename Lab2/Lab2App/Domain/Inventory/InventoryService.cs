using Lab2.Domain.Items;

namespace Lab2.Domain.Inventory
{
    internal class InventoryService
    {
        private readonly Inventory _inventory = new();

        public void AddItem(IItem item) => _inventory.AddItem(item);

        public bool RemoveItem(string name) => _inventory.RemoveItem(name);

        public void DisplayInventory() => _inventory.DisplayAll();

        public void EquipItem(string name)
        {
            var item = _inventory.Items.FirstOrDefault(i => i.Name == name);
            if (item == null)
            {
                Console.WriteLine($"Предмет '{name}' не найден.");
                return;
            }

            item.CurrentState.Equip(item);
        }

        public void UseItem(string name)
        {
            var item = _inventory.Items.FirstOrDefault(i => i.Name == name);
            if (item == null)
            {
                Console.WriteLine($"Предмет '{name}' не найден.");
                return;
            }

            if (item.UseStrategy == null)
            {
                Console.WriteLine($"У предмета {item.Name} нет стратегии использования.");
                return;
            }

            item.UseStrategy.Use();
            item.CurrentState.Use(item);
        }

        public IItem? FindItem(string name)
        {
            return _inventory.Items.FirstOrDefault(i => i.Name == name);
        }
    }
}
