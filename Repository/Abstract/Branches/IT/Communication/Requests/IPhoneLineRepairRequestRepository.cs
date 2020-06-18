using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    /// <summary>
    /// Класс доступа к хранилищу заявок ремонта телефонной линии
    /// </summary>
    public interface IPhoneLineRepairRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на ремонт телефонной линии
        /// </summary>
        /// <param name="request">Запись заявки на ремонт телефонной линии</param>
        /// <returns>Возвращает объект заявки на ремонт телефонной линии</returns>
        Task<PhoneLineRepairRequest> Add(PhoneLineRepairRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на ремонт телефонной линии
        /// </summary>
        /// <param name="request">Запись заявки на ремонт телефонной линии</param>
        /// <returns>Возвращает объект заявки на ремонт телефонной линии</returns>
        Task<PhoneLineRepairRequest> Update(PhoneLineRepairRequest request);
        /// <summary>
        /// Метод удаления записи заявки на ремонт телефонной линии
        /// </summary>
        /// <param name="request">Запись заявки на ремонт телефонной линии</param>
        /// <returns></returns>
        Task Delete(PhoneLineRepairRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на ремонт телефонной линии
        /// </summary>
        /// <returns>Возвращает список записей заявки на ремонт телефонной линии</returns>
        Task<List<PhoneLineRepairRequest>> GetRequests();
    }
}
