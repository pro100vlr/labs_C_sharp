using Lab2.Domain.Items;
// исчезающие предметы - зелье
namespace Lab2.Domain.States
{
    internal class ConsumedState : IItemState
    {
        public void Use(IItem item)
        {
            Console.WriteLine($"{item.Name} уже было использовано и исчезло.");
        }

        public void Equip(IItem item)
        {
            Console.WriteLine($"{item.Name} нельзя экипировать — оно использовано.");
        }

        public void Unequip(IItem item)
        {
            Console.WriteLine($"{item.Name} нельзя снять — оно больше не существует.");
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Предмет использован (consumed).");
        }
    }
}
