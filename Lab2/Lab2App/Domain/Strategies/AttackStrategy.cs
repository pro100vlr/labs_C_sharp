using System;

namespace Lab2.Domain.Strategies
{
    public class AttackStrategy : IUseStrategy
    {
        private int _damage;
        private int _enemyHp;

        public AttackStrategy(int damage, int enemyHp)
        {
            _damage = damage;
            _enemyHp = enemyHp;
        }

        public void Use()
        {
            Console.WriteLine($"Вы атаковали врага и нанесли {_damage} урона!");
            _enemyHp -= _damage;
            if (_enemyHp <= 0)
            {
                Console.WriteLine("Враг повержен!");
                _enemyHp = 0;
            }
            else
            {
                Console.WriteLine($"У врага осталось {_enemyHp} HP.");
            }
        }
    }
}
