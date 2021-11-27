using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Warehouse
    {
        Dictionary<Good, int> _items = new Dictionary<Good, int>();

        public bool HaveEnough(Good good, int number)
        {
            if (_items.ContainsKey(good))
            {
                if (_items[good] >= number)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public void Inc(Good good, int number)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "значение должно быть больше 0");

            if (_items.Keys.Contains(good))
                _items[good] += number;
            else
                _items.Add(good, number);
        }

        public void Dec(IEnumerable<Cell> cells)
        {
            // проверяем доступность ВСЕХ товаров
            foreach(var c in cells)
            {
                if (!HaveEnough(c.Good, c.Number))
                    throw new NotEnoughException($"Товара не достаточно на складе");
            }

            //списываем весь товар
            foreach(var c in cells)
            {
                Dec(c.Good, c.Number);
            }
        }

        public void Dec(Good good, int number)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "значение должно быть больше 0");

            if (HaveEnough(good, number))
                _items[good] -= number;
            else
                throw new ArgumentOutOfRangeException(nameof(number), "Недостаточное количество для списания");
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
    }
}
