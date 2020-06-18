using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на проведение телефонной линии
    /// </summary>
    public interface IHoldingPhoneLineRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение телефонной линии</param>
        /// <returns>Возвращает объект жизненного цикла заявки на проведение телефонной линии</returns>
        Task<HoldingPhoneLineRequestLifeCycle> Add(HoldingPhoneLineRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение телефонной линии</param>
        /// <returns>Возвращает объект жизненного цикла заявки на проведение телефонной линии</returns>
        Task<HoldingPhoneLineRequestLifeCycle> Update(HoldingPhoneLineRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение телефонной линии</param>
        /// <returns></returns>
        Task Delete(HoldingPhoneLineRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на проведение телефонной линии</returns>
        Task<List<HoldingPhoneLineRequestLifeCycle>> GetLifeCycles();
    }
}
