namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class, TEntity, new()
    {
        Task<T> Create(T obj);

        Task<T> Update(T obj);

        Task<bool> Delete(T obj);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();
    }
}
