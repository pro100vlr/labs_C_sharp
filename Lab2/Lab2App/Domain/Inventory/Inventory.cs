using Lab2.Domain.Items;

namespace Lab2.Domain.Inventory
{
    internal class Inventory
    {
        private readonly List<IItem> _items = new();

        public IReadOnlyCollection<IItem> Items => _items.AsReadOnly();

        public void AddItem(IItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _items.Add(item);
            Console.WriteLine($"Добавлен предмет: {item.Name}");
        }

        public bool RemoveItem(string name)
        {
            var item = _items.FirstOrDefault(i => i.Name == name);
            if (item == null)
            {
                Console.WriteLine($"Предмет {name} не найден.");
                return false;
            }

            _items.Remove(item);
            Console.WriteLine($"Удален предмет: {item.Name}");
            return true;
        }

        public IItem? FindItem(string name)
        {
            var item = _items.FirstOrDefault(i => i.Name == name);
            return item == null ? null : CloneItem(item);
        }

        private IItem CloneItem(IItem original)
        {
            return original.Clone();
        }

        public void DisplayAll()
        {
            Console.WriteLine("=== Инвентарь игрока ===");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.Name} [{item.Rarity}]");
            }
        }
    }
}
