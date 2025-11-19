using Lab2.Application;

namespace Lab2.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            var facade = new InventoryFacade();
            bool running = true;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Добро пожаловать в RPG Inventory System ===");

            facade.AddWeapon("Steel Sword", 6.5, "Rare", 30);
            facade.SetDamageBoostStrategy("Steel Sword", 15, 20);

            facade.AddArmor("Iron Armor", 10.0, "Uncommon", 15);
            // броня не имеет активного действия, оставляем без UseStrategy

            facade.AddPotion("Healing Potion", 0.5, "Common", "Healing");
            facade.SetHealStrategy("Healing Potion", 25);

            while (running)
            {
                Console.WriteLine("\n=== Главное меню ===");
                Console.WriteLine("1. Показать инвентарь");
                Console.WriteLine("2. Экипировать предмет");
                Console.WriteLine("3. Использовать предмет");
                Console.WriteLine("4. Улучшить оружие");
                Console.WriteLine("5. Добавить новый предмет");
                Console.WriteLine("6. Назначить стратегию предмету");
                Console.WriteLine("7. Атаковать врага");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        facade.DisplayInventory();
                        break;

                    case "2":
                        Console.Write("Введите название предмета для экипировки: ");
                        var equipName = Console.ReadLine();
                        facade.EquipItem(equipName ?? "");
                        break;

                    case "3":
                        Console.Write("Введите название предмета для использования: ");
                        var useName = Console.ReadLine();
                        facade.UseItem(useName ?? "");
                        break;

                    case "4":
                        Console.Write("Введите название оружия для улучшения: ");
                        var upgradeName = Console.ReadLine();
                        Console.Write("Введите бонус к урону: ");
                        if (int.TryParse(Console.ReadLine(), out int bonus))
                        {
                            facade.SetUpgradeWeaponStrategy(upgradeName ?? "", bonus);
                            facade.UseItem(upgradeName ?? "");
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение бонуса.");
                        }
                        break;

                    case "5":
                        AddNewItem(facade);
                        break;

                    case "6":
                        AssignStrategyMenu(facade);
                        break;
                    case "7":
    Console.Write("Введите название оружия для атаки: ");
    var attackName = Console.ReadLine();

    Console.Write("Введите урон оружия: ");
    int.TryParse(Console.ReadLine(), out int damage);

    Console.Write("Введите здоровье врага: ");
    int.TryParse(Console.ReadLine(), out int enemyHp);

    facade.SetAttackStrategy(attackName ?? "", damage, enemyHp);
    facade.UseItem(attackName ?? "");
    break;


                    case "0":
                        running = false;
                        Console.WriteLine("Выход из игры...");
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда, попробуйте снова.");
                        break;
                }
            }
        }

        static void AddNewItem(InventoryFacade facade)
        {
            Console.WriteLine("Выберите тип предмета:");
            Console.WriteLine("1. Оружие");
            Console.WriteLine("2. Броня");
            Console.WriteLine("3. Зелье");
            Console.WriteLine("4. Квестовый предмет");

            Console.Write("Тип: ");
            var type = Console.ReadLine();

            Console.Write("Название: ");
            var name = Console.ReadLine() ?? "Безымянный";

            Console.Write("Вес: ");
            double.TryParse(Console.ReadLine(), out double weight);

            Console.Write("Редкость: ");
            var rarity = Console.ReadLine() ?? "Обычный";

            switch (type)
            {
                case "1":
                    Console.Write("Урон: ");
                    int.TryParse(Console.ReadLine(), out int damage);
                    facade.AddWeapon(name, weight, rarity, damage);
                    break;

                case "2":
                    Console.Write("Защита: ");
                    int.TryParse(Console.ReadLine(), out int defense);
                    facade.AddArmor(name, weight, rarity, defense);
                    break;

                case "3":
                    Console.Write("Эффект зелья (Healing, DamageBoost и т.д.): ");
                    var effect = Console.ReadLine() ?? "Healing";
                    facade.AddPotion(name, weight, rarity, effect);
                    break;

                case "4":
                    Console.Write("Описание квестового предмета: ");
                    var desc = Console.ReadLine() ?? "Неизвестный предмет";
                    facade.AddQuestItem(name, weight, rarity, desc);
                    break;

                default:
                    Console.WriteLine("Неверный выбор типа предмета.");
                    break;
            }
        }

        static void AssignStrategyMenu(InventoryFacade facade)
        {
            Console.Write("Введите название предмета: ");
            var name = Console.ReadLine();

            Console.WriteLine("Выберите стратегию:");
            Console.WriteLine("1. Увеличить урон (DamageBoost)");
            Console.WriteLine("2. Исцелить (Heal)");
            Console.WriteLine("3. Улучшить оружие (Upgrade)");
            Console.Write("Выбор: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите бонус урона: ");
                    int.TryParse(Console.ReadLine(), out int dmg);
                    Console.Write("Введите длительность эффекта: ");
                    int.TryParse(Console.ReadLine(), out int dur);
                    facade.SetDamageBoostStrategy(name ?? "", dmg, dur);
                    break;

                case "2":
                    Console.Write("Введите количество HP для восстановления: ");
                    int.TryParse(Console.ReadLine(), out int heal);
                    facade.SetHealStrategy(name ?? "", heal);
                    break;

                case "3":
                    Console.Write("Введите бонус к урону при улучшении: ");
                    int.TryParse(Console.ReadLine(), out int upg);
                    facade.SetUpgradeWeaponStrategy(name ?? "", upg);
                    break;

                default:
                    Console.WriteLine("Неверный выбор стратегии.");
                    break;
            }
        }
    }
}
