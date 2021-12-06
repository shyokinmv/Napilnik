using System.Security.Cryptography;
using System.Text;

namespace Task04
{
    public interface IHash
    {
        string Create(string input);
    }

    public abstract class HashBase : IHash
    {
        protected abstract byte[] CalcHash(byte[] inputBytes);

        public virtual string Create(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = CalcHash(inputBytes);

            var sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }

    public class HashMD5 : HashBase
    {
        protected override byte[] CalcHash(byte[] inputBytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(inputBytes);
            }
        }
    }

    public class HashSHA1 : HashBase
    {
        protected override byte[] CalcHash(byte[] inputBytes)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(inputBytes);
            }
        }
    }
}
