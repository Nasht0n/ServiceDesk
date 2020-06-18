using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    /// <summary>
    /// Класс доступа к хранилищу заявок прокладки телефонной линии
    /// </summary>
    public interface IHoldingPhoneLineRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на прокладку телефонной линии
        /// </summary>
        /// <param name="request">Запись заявки на прокладку телефонной линии</param>
        /// <returns>Возвращает объект заявки на прокладку телефонной линии</returns>
        Task<HoldingPhoneLineRequest> Add(HoldingPhoneLineRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на прокладку телефонной линии
        /// </summary>
        /// <param name="request">Запись заявки на прокладку телефонной линии</param>
        /// <returns>Возвращает объект заявки на прокладку телефонной линии</returns>
        Task<HoldingPhoneLineRequest> Update(HoldingPhoneLineRequest request);
        /// <summary>
        /// Метод удаления записи заявки на прокладку телефонной линии
        /// </summary>
        /// <param name="request">Запись заявки на прокладку телефонной линии</param>
        /// <returns></returns>
        Task Delete(HoldingPhoneLineRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на прокладку телефонной линии
        /// </summary>
        /// <returns>Возвращает список записей заявки на прокладку телефонной линии</returns>
        Task<List<HoldingPhoneLineRequest>> GetRequests();
    }
}
