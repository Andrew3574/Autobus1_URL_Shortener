namespace Autobus1_Burlakov.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetByBatch(int batch, int batchSize = 10);
        Task<T?> GetById(int id);
        Task Update(T entity);
        Task Delete(int id);
        Task Create(T entity);

    }
}
