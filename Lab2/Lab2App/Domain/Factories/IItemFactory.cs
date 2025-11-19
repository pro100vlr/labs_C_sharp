using Lab2.Domain.Items;
// абсракный для всех фабрик - виден только он

namespace Lab2.Domain.Factories
{
    public interface IItemFactory
    {
        IItem CreateItem(string name, double weight, string rarity);
    }
}
