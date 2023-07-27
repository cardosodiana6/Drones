using Drones.Model.Context;
using Drones.Model.Entities;
using Drones.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Xsl;

namespace Drones.Model.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DronesDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DronesDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityResult = _dbSet.Update(entity).Entity;
            await _dbContext.SaveChangesAsync();
            return entityResult;
        }

        public DbSet<T> GetDbSet() 
        {
            return _dbSet;
        }

    }
}
