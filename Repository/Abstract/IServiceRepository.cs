using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейса доступа к хранилищу видов заявок
    /// </summary>
    public interface IServiceRepository
    {
        /// <summary>
        /// Метод добавления вида заявки
        /// </summary>
        /// <param name="service">Объект вида заявки</param>
        /// <returns>Возвращает добавленный объект вида заявки</returns>
        Task<Service> AddService(Service service);
        /// <summary>
        /// Метод обновления вида заявки
        /// </summary>
        /// <param name="service">Редактируемый вид заявки</param>
        /// <returns>Возвращает обновленный объект вида заявки</returns>
        Task<Service> UpdateService(Service service);
        /// <summary>
        /// Метод удаления вида заявки
        /// </summary>
        /// <param name="service">Объект вида заявки</param>
        /// <returns></returns>
        Task DeleteService(Service service);
        /// <summary>
        /// Метод получения списка видов заявок
        /// </summary>
        /// <returns>Возвращает список видов заявок</returns>
        Task<List<Service>> GetServices();
    }
}
