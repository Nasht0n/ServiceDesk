using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на увелечение объема почтового ящика
    /// </summary>
    public interface IEmailSizeIncreaseRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на увелечение объема почтового ящика
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на увелечение объема почтового ящика</param>
        /// <returns>Возвращает объект жизненного цикла заявки на увелечение объема почтового ящика</returns>
        Task<EmailSizeIncreaseRequestLifeCycle> Add(EmailSizeIncreaseRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на увелечение объема почтового ящика
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на увелечение объема почтового ящика</param>
        /// <returns>Возвращает объект жизненного цикла заявки на увелечение объема почтового ящика</returns>
        Task<EmailSizeIncreaseRequestLifeCycle> Update(EmailSizeIncreaseRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на увелечение объема почтового ящика
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на увелечение объема почтового ящика</param>
        /// <returns></returns>
        Task Delete(EmailSizeIncreaseRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на увелечение объема почтового ящика
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на увелечение объема почтового ящика</returns>
        Task<List<EmailSizeIncreaseRequestLifeCycle>> GetLifeCycles();
    }
}
