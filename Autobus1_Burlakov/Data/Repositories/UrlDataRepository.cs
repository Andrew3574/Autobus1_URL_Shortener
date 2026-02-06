using Autobus1_Burlakov.Data;
using Autobus1_Burlakov.Models;
using Microsoft.EntityFrameworkCore;

namespace Autobus1_Burlakov.Data.Repositories
{
    public class UrlDataRepository : IUrlDataRepository
    {
        private Autobus1dbContext _dbContext;

        public UrlDataRepository(Autobus1dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Urlsdatum entity)
        {
            try
            {
                _dbContext.Urlsdata.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR ON CREATE " + ex.Message+ex.InnerException);
            }
        }

        public async Task Delete(int id)
        {   
            try
            {
                _dbContext.Urlsdata.Remove(new Urlsdatum { Id=id});
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR ON DELETE " + ex.Message + ex.InnerException);
            } 
        }

        public async Task Update(Urlsdatum entity)
        {
            try
            {
                _dbContext.Urlsdata.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR ON UPDATE " + ex.Message + ex.InnerException);
            }
        }

        public async Task<List<Urlsdatum>> GetAll()
        {
            return await _dbContext.Urlsdata.ToListAsync();
        }

        public async Task<Urlsdatum?> GetById(int id)
        {
            return await _dbContext.Urlsdata.FirstOrDefaultAsync(e=>e.Id==id);
        }

        public bool ifShortUrlExists(string shortUrl)
        {
            return _dbContext.Urlsdata.Any(e=>e.ShortUrl==shortUrl);
        }

        public async Task<Urlsdatum?> GetUrlDatumByShortUrl(string shortUrl)
        {            
            return await _dbContext.Urlsdata.FirstOrDefaultAsync(e => e.ShortUrl == shortUrl);
        }

        public async Task<List<Urlsdatum>> GetByBatch(int batch, int batchSize = 10)
        {
            return await _dbContext.Urlsdata.Skip(batch*batchSize).Take(batchSize).ToListAsync();
        }
    }
}
