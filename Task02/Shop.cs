using System;
using System.Collections.Generic;

namespace Task02
{
    class Shop
    {
        Display _display;
        Warehouse _warehouse;

        List<Cart> _carts = new List<Cart>();

        public Shop(Warehouse warehouse, Display display)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _warehouse = warehouse;

            _display = display;
        }

        bool HaveEnough(Good good, int number)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "значение должно быть больше 0");

            return _warehouse.HaveEnough(good, number);
        }

        public Cart CreateCart()
        {
            var cart = new Cart(_display, canAdd: HaveEnough, _warehouse.Dec);
            _carts.Add(cart);
            return cart;
        }
    }
}
