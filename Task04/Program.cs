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
            var ps1 = new PaymentSystem1(order);
            Console.WriteLine(ps1.GetPayingLink());

            Console.WriteLine();

            //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
            var ps2 = new PaymentSystem2(order);
            Console.WriteLine(ps2.GetPayingLink());

            Console.WriteLine();

            //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
            var secretKey = "114E54176B9649339F38978B9A682FB2";
            var ps3 = new PaymentSystem3(order, secretKey);
            Console.WriteLine(ps3.GetPayingLink());

            Console.ReadKey();
        }
    }

    public class Order
    {
        public readonly int Id;
        public readonly int Amount;

        public Order(int id, int amount) => (Id, Amount) = (id, amount);
    }
}
