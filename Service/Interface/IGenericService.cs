using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IGenericService<T> where T : class
    {
        Task<Object> getAll(int pageIndex, int pageSize);
        Task<T> getById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
