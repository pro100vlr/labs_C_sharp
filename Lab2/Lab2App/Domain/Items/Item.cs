using Lab2.Domain.Strategies;
using Lab2.Domain.States;

namespace Lab2.Domain.Items
{
    public abstract class Item : IItem
    {
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public string Rarity { get; protected set; }

        public string Description { get; set; } = "";
        public IUseStrategy? UseStrategy { get; set; }
        public IItemState CurrentState { get; set; }

        protected Item(string name, double weight, string rarity)
        {
            Name = name;
            Weight = weight;
            Rarity = rarity;
            CurrentState = new InInventoryState();
        }

        public virtual void Use()
        {
            if (UseStrategy == null)
            {
                Console.WriteLine($"У предмета {Name} нет стратегии использования.");
                return;
            }

            UseStrategy.Use();

            CurrentState.Use(this);
        }

        public virtual void Equip() => CurrentState.Equip(this);

        public virtual void Unequip() => CurrentState.Unequip(this);

        public virtual void DisplayStatus() => CurrentState.DisplayStatus();

        // отображения информации о предмете
        public virtual string GetInfo()
        {
            return $"{Name} ({Rarity}), вес: {Weight}";
        }

        //  клонирования предмета
        public virtual IItem Clone()
        {
            return (IItem)this.MemberwiseClone();
        }
    }
}
