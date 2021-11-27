using System;
using System.Collections.Generic;

namespace Task02
{
    delegate void Display(string message);
    delegate void Decrease(IEnumerable<Cell> cells);
    delegate bool HaveEnough(Good good, int number);

    class ShopApp
    {
        Display _display;

        public ShopApp(Display display)
        {
            _display = display;
        }

        public void Run()
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            warehouse.Inc(iPhone12, 10);
            warehouse.Inc(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком
            Display();
            Display("Остатки на складе:");
            ShowGoodList(warehouse.GetCells());

            var shop = new Shop(warehouse, _display);

            Cart cart = shop.CreateCart();

            Display();
            Display("Добавляем товар в корзину");
            cart.TryAddToCart(iPhone12, 4);

            //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе
            cart.TryAddToCart(iPhone11, 3);

            //Вывод всех товаров в корзине
            Display();
            Display("Состав корзины:");
            ShowGoodList(cart.GetCells());

            Display();
            Display("Идентификатор заказа:");
            Display(cart.GetOrder().GetPaylink());

            Display();
            cart.TryAddToCart(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары

            //Console.ReadKey();
        }

        void Display(string message = null)
        {
            _display?.Invoke(message ?? "");
        }


        void ShowGoodList(IEnumerable<Cell> cells)
        {
            foreach (var cell in cells)
                Display($"{cell.Good} - {cell.Number}");
        }
    }
}
