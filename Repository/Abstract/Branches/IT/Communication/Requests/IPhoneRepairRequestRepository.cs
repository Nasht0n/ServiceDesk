using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на ремонт телефонного аппарата
    /// </summary>
    public interface IPhoneRepairRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на ремонт телефонного аппарата
        /// </summary>
        /// <param name="request">Запись заявки на ремонт телефонного аппарата</param>
        /// <returns>Возвращает объект заявки на ремонт телефонного аппарата</returns>
        Task<PhoneRepairRequest> Add(PhoneRepairRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на ремонт телефонного аппарата
        /// </summary>
        /// <param name="request">Запись заявки на ремонт телефонного аппарата</param>
        /// <returns>Возвращает объект заявки на ремонт телефонного аппарата</returns>
        Task<PhoneRepairRequest> Update(PhoneRepairRequest request);
        /// <summary>
        /// Метод удаления записи заявки на ремонт телефонного аппарата
        /// </summary>
        /// <param name="request">Запись заявки на ремонт телефонного аппарата</param>
        /// <returns></returns>
        Task Delete(PhoneRepairRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на ремонт телефонного аппарата
        /// </summary>
        /// <returns>Возвращает список записей заявки на ремонт телефонного аппарата</returns>
        Task<List<PhoneRepairRequest>> GetRequests();
    }
}
