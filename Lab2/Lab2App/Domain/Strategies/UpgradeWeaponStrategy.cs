using System;

namespace Lab2.Domain.Strategies
{
    public class UpgradeWeaponStrategy : IUseStrategy
    {
        private int _upgradeBonus;

        public UpgradeWeaponStrategy(int upgradeBonus)
        {
            _upgradeBonus = upgradeBonus;
        }

        public void Use()
        {
            Console.WriteLine($"Оружие улучшено: +{_upgradeBonus} к урону.");
        }
    }
}
