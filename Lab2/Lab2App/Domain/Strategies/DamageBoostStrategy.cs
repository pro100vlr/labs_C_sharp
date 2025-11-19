using System;

namespace Lab2.Domain.Strategies
{
    public class DamageBoostStrategy : IUseStrategy
    {
        private int _bonusDamage;
        private int _duration;

        public DamageBoostStrategy(int bonusDamage, int duration)
        {
            _bonusDamage = bonusDamage;
            _duration = duration;
        }

        public void Use()
        {
            Console.WriteLine($"Применён бонус к урону: +{_bonusDamage} на {_duration} ходов.");
        }
    }
}
