using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Softsige.Ideias.Domain.Entities.Models;
using Softsige.Ideias.Domain.Interfaces.Repository;
using Softsige.Ideias.Infrastructure.Context;

namespace Softsige.Ideias.Infrastructure.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntityModel<int>, new()
    {
        private readonly MarchesanIdeiasDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected Repository(MarchesanIdeiasDbContext db)
        {
            _dbContext = db;
            _dbSet = db.Set<T>();
        }

        public async Task<int> Add(T item)
        {
            await _dbSet.AddAsync(item);
            return await SaveChanges();
        }

        public async Task<int> Update(T item)
        {
            _dbSet.Update(item);
            return await SaveChanges();
        }

        public async Task<int> Delete(int id)
        {
            _dbSet.Remove(new T { Id = id });
            return await SaveChanges();
        }

        public async Task<int> Delete(T item)
        {
            _dbSet.Remove(new T { Id = item.Id });
            return await SaveChanges();
        }

        public async Task<T> FindById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}