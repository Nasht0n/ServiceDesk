using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок системы
    /// </summary>
    public interface IRequestRepository
    {
        /// <summary>
        /// Метод получения списка заявок системы
        /// </summary>
        /// <returns>Возвращает список заявок системы</returns>
        Task<List<Requests>> GetRequests();
    }
}
