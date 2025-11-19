// создание оружия сэффектом урона
using Lab2.Domain.Items;

namespace Lab2.Domain.Builders
{
    internal class WeaponBuilder : ItemBuilder<WeaponBuilder, IItem>
    {
        private int _damage = 10;

        public WeaponBuilder SetDamage(int damage)
        {
            _damage = damage;
            return this;
        }

        public override IItem Build()
        {
            return new Weapon(_name, _weight, _rarity, _damage);
        }
    }
}
