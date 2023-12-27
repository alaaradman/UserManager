using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IDtoServeices
{
    public interface IGenericDTO<T, M> where T : class 
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(M entity);
        Task<T> UpdateAsync(M entity);
        Task<T> DeleteAsync(string Id);
    }
}
