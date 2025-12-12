using System.Collections.Generic;
using System.Threading.Tasks;

namespace KyrsAPI.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}