using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на выделение телефонного номера
    /// </summary>
    public interface IPhoneNumberAllocationRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на выделение телефонного номера
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на выделение телефонного номера</param>
        /// <returns>Возвращает объект жизненного цикла заявки на выделение телефонного номераи</returns>
        Task<PhoneNumberAllocationRequestLifeCycle> Add(PhoneNumberAllocationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на выделение телефонного номера
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на выделение телефонного номера</param>
        /// <returns>Возвращает объект жизненного цикла заявки на выделение телефонного номера</returns>
        Task<PhoneNumberAllocationRequestLifeCycle> Update(PhoneNumberAllocationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на выделение телефонного номера
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на выделение телефонного номера</param>
        /// <returns></returns>
        Task Delete(PhoneNumberAllocationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на выделение телефонного номера
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на выделение телефонного номера</returns>
        Task<List<PhoneNumberAllocationRequestLifeCycle>> GetLifeCycles();
    }
}
