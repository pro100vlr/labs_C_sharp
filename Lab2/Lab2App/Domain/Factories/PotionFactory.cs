using Lab2.Domain.Items;

namespace Lab2.Domain.Factories
{
    internal class PotionFactory : IItemFactory
    {
        private readonly string _effect;

        public PotionFactory(string effect = "Healing")
        {
            _effect = effect;
        }

        public IItem CreateItem(string name, double weight, string rarity)
        {
            return new Potion(name, weight, rarity, _effect);
        }
    }
}
