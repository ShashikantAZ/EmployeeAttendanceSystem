using Microsoft.EntityFrameworkCore;
using SEA.Core;
using SEA.Core.Models;
using SEA.Data.ContextConfig;

namespace SEA.Data
{
    public class EntityframeworkRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : BaseEntity
    {

        private readonly DbContextFactory _dbContextFactory;
        private readonly DbContext _dbContext;

        public EntityframeworkRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _dbContext = _dbContextFactory.CreateDbContext();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {

            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
