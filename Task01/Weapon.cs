using System;

namespace Task01
{
    class Player
    {
        private int _health;

        public Action OnDamaged;
        public Action OnDie;

        public bool IsAlive => _health > 0;

        public Player(int health)
        {
            if (health > 0)
                _health = health;
            else
                throw new ArgumentOutOfRangeException(nameof(health));
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
                _health -= damage;
            else
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_health < 0)
                _health = 0;

            if (_health > 0)
                OnDamaged?.Invoke();
            else
                OnDie?.Invoke();
        }
    }

    class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage > 0)
                _damage = damage;
            else
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (bullets > 0)
                _bullets = bullets;
            else
                throw new ArgumentOutOfRangeException(nameof(bullets));
        }

        public bool HaveBullets => _bullets > 0;

        public void Fire(Player player)
        {
            if (HaveBullets)
            {
                _bullets -= 1;
                player.TakeDamage(_damage);
            }
            else
            {
                throw new Exception("кончились патроны");
            }
        }
    }

    class Bot
    {
        public Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            while (player.IsAlive
                && _weapon.HaveBullets)
                _weapon.Fire(player);
        }
    }
}
