using System.Collections.Generic;
using System.Threading.Tasks;
using Theatre.Web.Models;

namespace Theatre.Web.Repository
{
    public interface IRepository<T> where T : BaseEntity 
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T item);
        Task Delete(T item);
        Task Update(T item);
    }
}