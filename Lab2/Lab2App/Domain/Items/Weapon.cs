// оружие с уникальным свойством урон
namespace Lab2.Domain.Items
{
    internal class Weapon : Item
    {
        public int Damage { get; private set; }
        public bool IsEquipped { get; private set; }

        public Weapon(string name, double weight, string rarity, int damage)
            : base(name, weight, rarity)
        {
            Damage = damage;
        }

        public override void Use()
        {
            Console.WriteLine($"{Name} нанес {Damage} урона.");
        }

        public override void Equip()
        {
            if (!IsEquipped)
            {
                IsEquipped = true;
                Console.WriteLine($"{Name} экипировано.");
            }
        }

        public override void Unequip()
        {
            if (IsEquipped)
            {
                IsEquipped = false;
                Console.WriteLine($"{Name} снято.");
            }
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Damage: {Damage}";
        }
    }
}
