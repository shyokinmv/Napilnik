using System;

namespace Task02
{
    class NotEnoughException : Exception
    {
        public NotEnoughException(string message) : base(message) { }
    }
}
