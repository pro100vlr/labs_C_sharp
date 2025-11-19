// броня с уникальным свойством защита
namespace Lab2.Domain.Items
{
    internal class Armor : Item
    {
        public int Defense { get; private set; }
        public bool IsEquipped { get; private set; }

        public Armor(string name, double weight, string rarity, int defense)
            : base(name, weight, rarity)
        {
            Defense = defense;
        }

        public override void Use()
        {
            Console.WriteLine($"{Name} нельзя использовать напрямую — только экипировать.");
        }

        public override void Equip()
        {
            if (!IsEquipped)
            {
                IsEquipped = true;
                Console.WriteLine($"{Name} экипировано. Защита +{Defense}");
            }
        }

        public override void Unequip()
        {
            if (IsEquipped)
            {
                IsEquipped = false;
                Console.WriteLine($"{Name} снято. Защита снята.");
            }
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Defense: {Defense}";
        }
    }
}
