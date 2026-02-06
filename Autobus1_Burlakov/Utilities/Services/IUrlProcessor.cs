using System.Security;

namespace Autobus1_Burlakov.Utilities.Services
{
    public interface IUrlProcessor
    {
        /// <summary>
        /// Returns unique short version of entered URL
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <returns></returns>
        string ShortenUrl(string fullUrl);
    }
}
