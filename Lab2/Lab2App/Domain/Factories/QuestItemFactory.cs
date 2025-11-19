using Lab2.Domain.Items;

namespace Lab2.Domain.Factories
{
    internal class QuestItemFactory : IItemFactory
    {
        private readonly string _questId;

        public QuestItemFactory(string questId)
        {
            _questId = questId;
        }

        public IItem CreateItem(string name, double weight, string rarity)
        {
            return new QuestItem(name, weight, rarity, _questId);
        }
    }
}
