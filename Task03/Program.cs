using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathFinder1 = new PathFinder(new ConsoleLogWritter());
            pathFinder1.Find("только в консоль");

            var pathFinder2 = new PathFinder(new SecureLogWritter(new ConsoleLogWritter()));
            pathFinder2.Find("только в консоль только по пятницам"); 
            
            var pathFinder3 = new PathFinder(new FileLogWritter());
            pathFinder3.Find("только в файл");

            var pathFinder4 = new PathFinder(new SecureLogWritter(new FileLogWritter()));
            pathFinder4.Find("только в файл только по пятницам");

            var pathFinder5 = new PathFinder(MultiLogWriter.Create(new ConsoleLogWritter(), new SecureLogWritter(new FileLogWritter())));
            pathFinder5.Find("в консоль и в файл по пятницам");
        }
    }
}
