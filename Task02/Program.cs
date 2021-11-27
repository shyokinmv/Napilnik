using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopApp = new ShopApp(Display);
            shopApp.Run();

            Console.ReadKey();
        }

        static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
