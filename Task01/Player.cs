using System;

namespace Task01
{
    public class Player : IDamagable
    {
        private int _health;

        public event Action Damaged;
        public event Action Die;

        public bool IsAlive => _health > 0;

        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _health -= damage;

            if (_health < 0)
                _health = 0;

            if (IsAlive)
                Damaged?.Invoke();
            else
                Die?.Invoke();
        }
    }
}
