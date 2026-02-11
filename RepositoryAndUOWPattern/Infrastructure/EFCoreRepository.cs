using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    internal class EFCoreRepository<T> : IRepository<T> where T : class, TEntity, new()
    {
        private readonly DbSet<T> entity;

        public EFCoreRepository(EFContext context) 
        {
            entity = context.Set<T>();
        }

        public async Task<T> Create(T obj)
        {
           await this.entity.AddAsync(obj);
            return obj;
        }

        public async Task<bool> Delete(T obj)
        {
            var model = this.entity.Where(x => x.Id == obj.Id).FirstOrDefault();

            if (model != null)
            {
                this.entity.Remove(model);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await this.entity.ToListAsync();
            return data;
        }

        public async Task<T> GetById(int id)
        {
            var data = await this.entity.FirstOrDefaultAsync(x => x.Id == id);

            return data ?? new T();
        }

        public async Task<T> Update(T obj)
        {
            var data = await this.entity.FirstOrDefaultAsync(x => x.Id == obj.Id);

            if (data != null)
            {
                this.entity.Update(obj);
                return obj;
            }

            throw new Exception("Not valid");
        }
    }
}
 