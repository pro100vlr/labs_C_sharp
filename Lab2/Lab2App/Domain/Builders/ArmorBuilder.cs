// создание брони с эффектом защиты
using Lab2.Domain.Items;

namespace Lab2.Domain.Builders
{
    internal class ArmorBuilder : ItemBuilder<ArmorBuilder, IItem>
    {
        private int _defense = 5;

        public ArmorBuilder SetDefense(int defense)
        {
            _defense = defense;
            return this;
        }

        public override IItem Build()
        {
            return new Armor(_name, _weight, _rarity, _defense);
        }
    }
}
