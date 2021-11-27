using System;
using System.Collections.Generic;

namespace Task02
{
    class Order
    {
        Decrease _decreaseOnWarehouse;
        string _paylink;

        IEnumerable<Cell> _cells;

        public Order(IEnumerable<Cell> cells, Decrease decreaseOnWarehouse)
        {
            _cells = cells;
            _decreaseOnWarehouse = decreaseOnWarehouse;
        }

        public string GetPaylink()
        {
            _paylink = Guid.NewGuid().ToString("N");

            _decreaseOnWarehouse?.Invoke(_cells);
            
            return _paylink;
        }
    }
}
