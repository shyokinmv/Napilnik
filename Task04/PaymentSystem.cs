namespace Task04
{
    public interface IPaymentSystem
    {
        public string GetPayingLink(Order order);
    }

    public abstract class PaymentSystemBase : IPaymentSystem
    {
        private readonly string _baseLink;
        private readonly IHash _hash;

        protected PaymentSystemBase(string baseLink, IHash hash)
        {
            _baseLink = baseLink;
            _hash = hash;
        }

        protected string CalcHash(Order order)
        {
            return _hash.Create(GetHashInput(order));
        }

        public string GetPayingLink(Order order)
        {
            var parameters = GetLinkParameters(order);
            var fullLink = $"{_baseLink}?{parameters}";
            return fullLink;
        }

        protected abstract string GetLinkParameters(Order order);

        protected abstract string GetHashInput(Order order);
    }

    /// <summary>
    /// pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
    /// </summary>
    public class PaymentSystem1 : PaymentSystemBase
    {
        public PaymentSystem1(string baseLink, IHash hash) : base(baseLink, hash) { }

        protected override string GetLinkParameters(Order order)
        {
            var hash = CalcHash(order);
            return $"amount={order.Amount}RUB&hash={hash}";
        }

        protected override string GetHashInput(Order order)
        {
            return order.Id.ToString();
        }
    }

    /// <summary>
    /// order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
    /// </summary>
    public class PaymentSystem2 : PaymentSystemBase
    {
        public PaymentSystem2(string baseLink, IHash hash) : base(baseLink, hash) { }

        protected override string GetLinkParameters(Order order)
        {
            var hash = CalcHash(order);
            return $"hash={hash}";
        }

        protected override string GetHashInput(Order order)
        {
            return (order.Id + order.Amount).ToString();
        }
    }

    /// <summary>
    /// system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
    /// </summary>
    public class PaymentSystem3 : PaymentSystemBase
    {
        string _secretKey;

        public PaymentSystem3(string baseLink, string secretKey, IHash hash) : base(baseLink, hash) 
        {
            _secretKey = secretKey;
        }

        protected override string GetLinkParameters(Order order) 
        {
            var hash = CalcHash(order);
            return $"amount={order.Amount}&currency=RUB&hash={hash}";
        }

        protected override string GetHashInput(Order order)
        {
            return order.Id.ToString() + order.Amount.ToString() + _secretKey;
        }
    }

}
