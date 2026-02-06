using Autobus1_Burlakov.Models;

namespace Autobus1_Burlakov.Data.Repositories
{
    public interface IUrlDataRepository : IRepository<Urlsdatum>
    {
        bool ifShortUrlExists(string shortUrl);
        Task<Urlsdatum?> GetUrlDatumByShortUrl(string shortUrl);
    }
}
