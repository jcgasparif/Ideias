using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Softsige.Ideias.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable
    {
        Task<int> Add(T item);

        Task<int> Update(T item);

        Task<int> Delete(int id);

        Task<int> Delete(T item);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> FindAll();

        Task<int> SaveChanges();
    }
}