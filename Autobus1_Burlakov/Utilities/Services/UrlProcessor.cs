using System.Buffers.Text;
using Bogus;

namespace Autobus1_Burlakov.Utilities.Services
{
    public class UrlProcessor : IUrlProcessor
    {
        private Hashids _hashids;
        private Random _random;

        public UrlProcessor()
        {
            _hashids = new Hashids(Guid.NewGuid().ToString(), 6);
            _random = new Random();
        }
        public string ShortenUrl(string fullUrl)
        {
            return _hashids.EncodeLong(GetRandomNumber(), GetFullUrlHashCode(fullUrl));
        }

        private int GetRandomNumber()
        {
            return _random.Next(100);
        }

        private int GetFullUrlHashCode(string fullUrl)
        {
            return Math.Abs(fullUrl.GetHashCode());
        }
    }
}
