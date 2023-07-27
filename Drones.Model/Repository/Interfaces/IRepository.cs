using Drones.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Model.Repository.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);

        Task<T?> GetById(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> UpdateAsync(T entity);

        DbSet<T> GetDbSet();
    }
}
