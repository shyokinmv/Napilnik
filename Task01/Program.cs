using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем игрока
            var player = new Player(health: 10);
            player.OnDamaged += PlayerDamaged;
            player.OnDie += PlayerDied;

            // создаем бота с оружием
            var weapon = new Weapon(damage: 6, bullets: 10);
            var bot = new Bot(weapon);

            bot.OnSeePlayer(player);

            Console.ReadKey();
        }

        private static void PlayerDamaged()
        {
            Console.WriteLine("Игрок ранен");
        }

        private static void PlayerDied()
        {
            Console.WriteLine("Игрок убит");
        }

    }
}
