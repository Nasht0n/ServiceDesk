using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на проведение видеосвязи
    /// </summary>
    public interface IVideoCommunicationRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на проведение видеосвязи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение видеосвязи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на проведение видеосвязи</returns>
        Task<VideoCommunicationRequestLifeCycle> Add(VideoCommunicationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на проведение видеосвязи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение видеосвязи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на проведение видеосвязи</returns>
        Task<VideoCommunicationRequestLifeCycle> Update(VideoCommunicationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на проведение видеосвязи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение видеосвязи</param>
        /// <returns></returns>
        Task Delete(VideoCommunicationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на проведение видеосвязи
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на проведение видеосвязи</returns>
        Task<List<VideoCommunicationRequestLifeCycle>> GetLifeCycles();
    }
}
