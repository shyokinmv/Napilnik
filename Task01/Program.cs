﻿using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем игрока
            var player = new Player(health: 10);

            // создаем бота с оружием
            var weapon = new Weapon(damage: 6, bullets: 10);
            var bot = new Bot(weapon);

            bot.Fire(player);
            bot.Fire(player);

            Console.ReadKey();
        }
    }
}
