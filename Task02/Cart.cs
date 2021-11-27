using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    class Cart
    {
        Dictionary<Good, int> _items = new Dictionary<Good, int>();

        Display _display;
        HaveEnough _canAdd;
        Decrease _decrease;

        public Cart(Display display, HaveEnough canAdd, Decrease decrease)
        {
            _display = display;
            _canAdd = canAdd;
            _decrease = decrease;
        }

        public bool TryAddToCart(Good good, int number)
        {
            try
            {
                Add(good, number);
                _display?.Invoke($"\"{good}\" ({number}) успешно добавлен в корзину");
                return true;
            }
            catch (NotEnoughException ex)
            {
                _display?.Invoke($"\"{good}\" ({number}) не может быть добавлен в корзину по причине:{Environment.NewLine}{ex.Message}");
                return false;
            }
        }

        public void Add(Good good, int number)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "значение должно быть больше 0");

            var haveEnough = _canAdd?.Invoke(good, number) ?? false;
            if (haveEnough)
            {
                if (_items.Keys.Contains(good))
                    _items[good] += number;
                else
                    _items.Add(good, number);
            }
            else
            {
                throw new NotEnoughException($"товара \"{good}\" ({number}) недостаточно на складе");
            }
        }

        public IEnumerable<Cell> GetCells()
        {
            var items = new List<Cell>();
            foreach (var item in _items)
            {
                var cell = new Cell(item.Key, item.Value);
                items.Add(cell);
            }
            return items;
        }

        internal Order GetOrder()
        {
            var order = new Order(GetCells(), _decrease);
            ClearCart();
            return order;
        }

        private void ClearCart()
        {
            _items = new Dictionary<Good, int>();
        }
    }
}
