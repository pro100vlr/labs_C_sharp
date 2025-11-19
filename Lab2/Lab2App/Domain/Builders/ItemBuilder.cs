// абстрактный, определяем базовые шаги
using Lab2.Domain.Items;

namespace Lab2.Domain.Builders
{
    internal abstract class ItemBuilder<TBuilder, TItem>
        where TBuilder : ItemBuilder<TBuilder, TItem>
        where TItem : IItem
    {
        protected string _name = "Unnamed";
        protected double _weight = 1.0;
        protected string _rarity = "Common";

        public TBuilder SetName(string name)
        {
            _name = name;
            return (TBuilder)this;
        }

        public TBuilder SetWeight(double weight)
        {
            _weight = weight;
            return (TBuilder)this;
        }

        public TBuilder SetRarity(string rarity)
        {
            _rarity = rarity;
            return (TBuilder)this;
        }

        public abstract TItem Build();
    }
}
