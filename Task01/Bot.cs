using System;

namespace Task01
{
    public class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            _weapon = weapon;
        }

        public void Fire(Player target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            _weapon.Fire(target);
        }
    }
}
