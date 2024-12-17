using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_csharp_application.src.Domain._Shared.Repository
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> FindAsync(string id);
        Task<IEnumerable<T>> FindAllAsync();
    }
}
