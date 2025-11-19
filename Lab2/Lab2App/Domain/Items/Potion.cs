// зелье - можно только использовать, без жкипирования
namespace Lab2.Domain.Items
{
    internal class Potion : Item
    {
        public string Effect { get; private set; }

        public Potion(string name, double weight, string rarity, string effect)
            : base(name, weight, rarity)
        {
            Effect = effect;
        }

        public override void Use()
        {
            Console.WriteLine($"{Name} использовано. Эффект: {Effect}");
        }

        public override void Equip()
        {
            Console.WriteLine($"{Name} нельзя экипировать.");
        }

        public override void Unequip()
        {
            Console.WriteLine($"{Name} нельзя снять — это зелье.");
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Effect: {Effect}";
        }
    }
}
