using Lab2.Domain.Items;

namespace Lab2.Domain.Factories
{
    internal class WeaponFactory : IItemFactory
    {
        private readonly int _baseDamage;

        public WeaponFactory(int baseDamage = 10)
        {
            _baseDamage = baseDamage;
        }

        public IItem CreateItem(string name, double weight, string rarity)
        {
            return new Weapon(name, weight, rarity, _baseDamage);
        }
    }
}
