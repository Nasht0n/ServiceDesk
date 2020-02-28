using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IServiceDeskRepository<T>
    {
        Task<T> Insert(T record);
        Task<T> Update(T record);
        Task Delete(T record);
        Task<List<T>> GetList();
    }
}
