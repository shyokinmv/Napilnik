using System;

namespace Task01
{
    public class Weapon
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
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (!HaveBullets)
                throw new InvalidOperationException("кончились патроны");

            _bullets -= 1;
            target.TakeDamage(_damage);
        }
    }
}
