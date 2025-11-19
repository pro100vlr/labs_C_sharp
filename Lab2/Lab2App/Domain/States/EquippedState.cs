using Lab2.Domain.Items;
// состояние экипировки
namespace Lab2.Domain.States
{
    internal class EquippedState : IItemState
    {
        public void Use(IItem item)
        {
            Console.WriteLine($"{item.Name} уже экипировано и используется.");
        }

        public void Equip(IItem item)
        {
            Console.WriteLine($"{item.Name} уже экипировано.");
        }

        public void Unequip(IItem item)
        {
            Console.WriteLine($"{item.Name} снято и возвращено в инвентарь.");
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Предмет экипирован.");
        }
    }
}
