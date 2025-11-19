using Lab2.Domain.Factories;
using Lab2.Domain.Inventory;
using Lab2.Domain.Items;
using Lab2.Domain.Strategies;

namespace Lab2.Application
{
    public class InventoryFacade
    {
        private readonly InventoryService _inventoryService;

        public InventoryFacade()
        {
            _inventoryService = new InventoryService();
        }


        public void AddWeapon(string name, double weight, string rarity, int damage)
        {
            IItemFactory factory = new WeaponFactory(damage);
            var item = factory.CreateItem(name, weight, rarity);
            _inventoryService.AddItem(item);
        }

        public void AddArmor(string name, double weight, string rarity, int defense)
        {
            IItemFactory factory = new ArmorFactory(defense);
            var item = factory.CreateItem(name, weight, rarity);
            _inventoryService.AddItem(item);
        }

        public void AddPotion(string name, double weight, string rarity, string effect)
        {
            IItemFactory factory = new PotionFactory(effect);
            var item = factory.CreateItem(name, weight, rarity);
            _inventoryService.AddItem(item);
        }

        public void AddQuestItem(string name, double weight, string rarity, string description)
        {
            IItemFactory factory = new QuestItemFactory(description);
            var item = factory.CreateItem(name, weight, rarity);
            _inventoryService.AddItem(item);
        }


        public void UseItem(string name)
        {
            _inventoryService.UseItem(name);
        }

        public void EquipItem(string name)
        {
            _inventoryService.EquipItem(name);
        }

        public void RemoveItem(string name)
        {
            _inventoryService.RemoveItem(name);
        }

        public void DisplayInventory()
        {
            _inventoryService.DisplayInventory();
        }

        // === Применение стратегий ===

        public void SetHealStrategy(string itemName, int healAmount)
        {
            SetStrategy(itemName, new HealStrategy(healAmount));
        }

        public void SetDamageBoostStrategy(string itemName, int bonusDamage, int durationSeconds)
        {
            SetStrategy(itemName, new DamageBoostStrategy(bonusDamage, durationSeconds));
        }

        public void SetUpgradeWeaponStrategy(string itemName, int upgradeAmount)
        {
            SetStrategy(itemName, new UpgradeWeaponStrategy(upgradeAmount));
        }

        private void SetStrategy(string itemName, IUseStrategy strategy)
        {
            // Оборачиваем через InventoryService, чтобы не выдать наружу ссылку на предмет
            var item = _inventoryService
                .GetType()
                .GetField("_inventory", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(_inventoryService) as dynamic;

            var found = ((IEnumerable<IItem>)item.Items).FirstOrDefault(i => i.Name == itemName);
            if (found != null)
            {
                found.UseStrategy = strategy;
                Console.WriteLine($"Стратегия использования для '{itemName}' назначена: {strategy.GetType().Name}");
            }
            else
            {
                Console.WriteLine($"Предмет '{itemName}' не найден для назначения стратегии.");
            }
        }

        public void SetAttackStrategy(string itemName, int damage, int enemyHp)
{
    var item = _inventoryService.FindItem(itemName);
    if (item == null)
    {
        Console.WriteLine($"Предмет '{itemName}' не найден.");
        return;
    }

    item.UseStrategy = new AttackStrategy(damage, enemyHp);
    Console.WriteLine($"Стратегия атаки назначена предмету '{itemName}'.");
}

    }
}
