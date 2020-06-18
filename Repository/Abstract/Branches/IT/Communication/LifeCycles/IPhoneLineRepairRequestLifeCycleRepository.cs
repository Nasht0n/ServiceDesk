using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на ремонт телефонной линии
    /// </summary>
    public interface IPhoneLineRepairRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на ремонт телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт телефонной линии</param>
        /// <returns>Возвращает объект жизненного цикла заявки на ремонт телефонной линии</returns>
        Task<PhoneLineRepairRequestLifeCycle> Add(PhoneLineRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на ремонт телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт телефонной линии</param>
        /// <returns>Возвращает объект жизненного цикла заявки на ремонт телефонной линии</returns>
        Task<PhoneLineRepairRequestLifeCycle> Update(PhoneLineRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на ремонт телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт телефонной линии</param>
        /// <returns></returns>
        Task Delete(PhoneLineRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на ремонт телефонной линии
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на ремонт телефонной линии</returns>
        Task<List<PhoneLineRepairRequestLifeCycle>> GetLifeCycles();
    }
}
