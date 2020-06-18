using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    /// <summary>
    /// Класс доступа к хранилищу жизненного цикла заявки на ремонт телефонного аппарата
    /// </summary>
    public interface IPhoneRepairRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на ремонт телефонного аппарата
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт телефонного аппарата</param>
        /// <returns>Возвращает объект жизненного цикла заявки на ремонт телефонного аппарата</returns>
        Task<PhoneRepairRequestLifeCycle> Add(PhoneRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на ремонт телефонного аппарата
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт телефонного аппарата</param>
        /// <returns>Возвращает объект жизненного цикла заявки на ремонт телефонного аппарата</returns>
        Task<PhoneRepairRequestLifeCycle> Update(PhoneRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на ремонт телефонного аппарата
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт телефонного аппарата</param>
        /// <returns></returns>
        Task Delete(PhoneRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на ремонт телефонного аппарата
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на ремонт телефонного аппарата</returns>
        Task<List<PhoneRepairRequestLifeCycle>> GetLifeCycles();
    }
}
