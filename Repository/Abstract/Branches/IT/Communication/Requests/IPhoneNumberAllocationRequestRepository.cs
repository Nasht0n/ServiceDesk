using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок выделения телефонного номера
    /// </summary>
    public interface IPhoneNumberAllocationRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на выделение телефонного номера
        /// </summary>
        /// <param name="request">Запись заявки на выделение телефонного номера</param>
        /// <returns>Возвращает объект заявки на выделение телефонного номера</returns>
        Task<PhoneNumberAllocationRequest> Add(PhoneNumberAllocationRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на выделение телефонного номера
        /// </summary>
        /// <param name="request">Запись заявки на выделение телефонного номера</param>
        /// <returns>Возвращает объект заявки на выделение телефонного номера</returns>
        Task<PhoneNumberAllocationRequest> Update(PhoneNumberAllocationRequest request);
        /// <summary>
        /// Метод удаления записи заявки на выделение телефонного номера
        /// </summary>
        /// <param name="request">Запись заявки на выделение телефонного номера</param>
        /// <returns></returns>
        Task Delete(PhoneNumberAllocationRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на выделение телефонного номера
        /// </summary>
        /// <returns>Возвращает список записей заявки на выделение телефонного номера</returns>
        Task<List<PhoneNumberAllocationRequest>> GetRequests();
    }
}
