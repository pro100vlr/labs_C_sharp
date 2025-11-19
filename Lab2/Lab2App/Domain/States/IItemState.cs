using Lab2.Domain.Items;

namespace Lab2.Domain.States
{
    public interface IItemState
    {
        void Use(IItem item);
        void Equip(IItem item);
        void Unequip(IItem item);
        void DisplayStatus();
    }
}
