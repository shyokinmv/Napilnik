namespace Task01
{
    public class Bot
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
