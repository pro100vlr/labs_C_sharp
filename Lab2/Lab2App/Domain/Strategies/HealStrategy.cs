using System;

namespace Lab2.Domain.Strategies
{
    public class HealStrategy : IUseStrategy
    {
        private int _healAmount;

        public HealStrategy(int healAmount)
        {
            _healAmount = healAmount;
        }

        public void Use()
        {
            Console.WriteLine($"Использовано зелье исцеления: восстанавливает {_healAmount} HP.");
        }
    }
}
