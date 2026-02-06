using System.Security;

namespace Autobus1_Burlakov.Utilities.Services
{
    public interface IUrlProcessor
    {
        string ShortenUrl(string fullUrl);
    }
}
