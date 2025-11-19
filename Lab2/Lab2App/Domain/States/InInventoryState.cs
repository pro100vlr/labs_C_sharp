using Lab2.Domain.Items;
// начальное состояние всех предметов
namespace Lab2.Domain.States
{
    internal class InInventoryState : IItemState
    {
        public void Use(IItem item)
        {
            Console.WriteLine($"{item.Name} используется прямо из инвентаря.");
        }

        public void Equip(IItem item)
        {
            Console.WriteLine($"{item.Name} теперь экипировано.");
        }

        public void Unequip(IItem item)
        {
            Console.WriteLine($"{item.Name} не экипировано, нельзя снять.");
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Предмет находится в инвентаре.");
        }
    }
}
