using Autobus1_Burlakov.Models;

namespace Autobus1_Burlakov.Data.Repositories
{
    public interface IUrlDataRepository : IRepository<Urlsdatum>
    {
        /// <summary>
        /// Checks if UrlData exists in DB to prevent collision
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        bool ifShortUrlExists(string shortUrl);

        Task<Urlsdatum?> GetUrlDatumByShortUrl(string shortUrl);
    }
}
