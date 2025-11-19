// квестовый предмет - только хранение
namespace Lab2.Domain.Items
{
    internal class QuestItem : Item
    {
        public string QuestId { get; private set; }

        public QuestItem(string name, double weight, string rarity, string questId)
            : base(name, weight, rarity)
        {
            QuestId = questId;
        }

        public override void Use()
        {
            Console.WriteLine($"{Name} нельзя использовать напрямую. Это квестовый предмет.");
        }

        public override void Equip()
        {
            Console.WriteLine($"{Name} нельзя экипировать. Это квестовый предмет.");
        }

        public override void Unequip()
        {
            Console.WriteLine($"{Name} нельзя снять. Это квестовый предмет.");
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Quest ID: {QuestId}";
        }
    }
}
