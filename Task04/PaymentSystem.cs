namespace Task04
{
    public interface IPaymentSystem
    {
        public string GetPayingLink();
    }

    public abstract class PaymentSystemBase : IPaymentSystem
    {
        private string _baseLink;
        private IHash _hash;
        protected string Hash => _hash.Create(GetHashInput());
        protected Order _order;

        protected PaymentSystemBase(string baseLink, Order order, IHash hash)
        {
            _baseLink = baseLink;
            _order = order;
            _hash = hash;
        }

        public string GetPayingLink()
        {
            var parameters = GetLinkParameters();
            var fullLink = $"{_baseLink}?{parameters}";
            return fullLink;
        }

        protected abstract string GetLinkParameters();

        protected abstract string GetHashInput();
    }

    /// <summary>
    /// pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
    /// </summary>
    public class PaymentSystem1 : PaymentSystemBase
    {
        public PaymentSystem1(Order order) : base(baseLink: "pay.system1.ru/order", order, new HashMD5()) { }

        protected override string GetLinkParameters()
        {
            return $"amount={_order.Amount}RUB&hash={Hash}";
        }

        protected override string GetHashInput()
        {
            return _order.Id.ToString();
        }
    }

    /// <summary>
    /// order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
    /// </summary>
    public class PaymentSystem2 : PaymentSystemBase
    {
        public PaymentSystem2(Order order) : base(baseLink: "order.system2.ru/pay", order, new HashMD5()) { }

        protected override string GetLinkParameters()
        {
            return $"hash={Hash}";
        }

        protected override string GetHashInput()
        {
            return (_order.Id + _order.Amount).ToString();
        }
    }

    /// <summary>
    /// system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
    /// </summary>
    public class PaymentSystem3 : PaymentSystemBase
    {
        string _secretKey;

        public PaymentSystem3(Order order, string secretKey) : base(baseLink: "system3.com/pay", order, new HashSHA1()) 
        {
            _secretKey = secretKey;
        }

        protected override string GetLinkParameters()
        {
            return $"amount={_order.Amount}&currency=RUB&hash={Hash}";
        }

        protected override string GetHashInput()
        {
            return _order.Id.ToString() + _order.Amount.ToString() + _secretKey;
        }
    }
}
