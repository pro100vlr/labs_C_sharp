using Lab2.Domain.Strategies;
using Lab2.Domain.States;

namespace Lab2.Domain.Items
{
    public interface IItem
    {
        string Name { get; }
        double Weight { get; }
        string Rarity { get; }

        string Description { get; set; }
        IUseStrategy? UseStrategy { get; set; }
        IItemState CurrentState { get; set; }

        void Use();
        void Equip();
        void Unequip();
        void DisplayStatus();

        IItem Clone();
    }
}
