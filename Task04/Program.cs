using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order(id: 12345678, amount: 12000);

            //Выведите платёжные ссылки для трёх разных систем платежа: 
            //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
            var ps1 = new PaymentSystem1(baseLink: "pay.system1.ru/order", new HashMD5());
            Console.WriteLine(ps1.GetPayingLink(order));

            Console.WriteLine();

            //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
            var ps2 = new PaymentSystem2(baseLink: "order.system2.ru/pay", new HashMD5());
            Console.WriteLine(ps2.GetPayingLink(order));

            Console.WriteLine();

            //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
            var secretKey = "114E54176B9649339F38978B9A682FB2";
            var ps3 = new PaymentSystem3(baseLink: "system3.com/pay", secretKey, new HashSHA1());
            Console.WriteLine(ps3.GetPayingLink(order));

            Console.ReadKey();
        }
    }
}
