using System;

namespace Task01
{
    class Player
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

            if (_health > 0)
                Damaged?.Invoke();
            else
                Die?.Invoke();
        }
    }

    class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            _damage = damage;
            _bullets = bullets;
        }

        public bool HaveBullets => _bullets > 0;

        public void Fire(Player target)
        {
            if (!HaveBullets)
                throw new ArgumentOutOfRangeException(nameof(_bullets), "кончились патроны");

            _bullets -= 1;
            target.TakeDamage(_damage);
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void Fire(Player target)
        {
            _weapon.Fire(target);
        }
    }
}
