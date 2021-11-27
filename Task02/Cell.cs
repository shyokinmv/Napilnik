using System;

namespace Task02
{
    class Cell
    {
        public Good Good { get; private set; }
        public int Number { get; private set; }

        public Cell(Good good, int number)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "значение должно быть больше 0");

            Good = good;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Good.Name} ({Number})";
        }
    }
}
