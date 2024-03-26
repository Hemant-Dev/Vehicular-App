using Microsoft.EntityFrameworkCore;
using Vehicular.Data;
using Vehicular.IRepositories;

namespace Vehicular.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly VehicularAppDbContext _dbContext;
        public Repository(VehicularAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            if(entity != null)
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();    
                return entity;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entityList = await _dbContext.Set<T>().ToListAsync();
            if(entityList != null)
            {
                return entityList;
            }
            return null;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if(entity != null)
            {
                return entity;
            }
            return null;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var oldEntity = await _dbContext.Set<T>().FindAsync(id);
            if(oldEntity != null)
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
