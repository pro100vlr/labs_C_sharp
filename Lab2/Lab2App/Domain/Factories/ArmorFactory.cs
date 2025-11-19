using Lab2.Domain.Items;

namespace Lab2.Domain.Factories
{
    internal class ArmorFactory : IItemFactory
    {
        private readonly int _baseDefense;

        public ArmorFactory(int baseDefense = 5)
        {
            _baseDefense = baseDefense;
        }

        public IItem CreateItem(string name, double weight, string rarity)
        {
            return new Armor(name, weight, rarity, _baseDefense);
        }
    }
}
