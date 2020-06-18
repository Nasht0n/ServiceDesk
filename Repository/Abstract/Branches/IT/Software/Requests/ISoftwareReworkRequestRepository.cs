using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на доработку программного обеспечения
    /// </summary>
    public interface ISoftwareReworkRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на доработку программного обеспечения
        /// </summary>
        /// <param name="request">Запись заявки на доработку программного обеспечения</param>
        /// <returns>Возвращает объект заявки на доработку программного обеспечения</returns>
        Task<SoftwareReworkRequest> Add(SoftwareReworkRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на доработку программного обеспечения
        /// </summary>
        /// <param name="request">Запись заявки на доработку программного обеспечения</param>
        /// <returns>Возвращает объект заявки на доработку программного обеспечения</returns>
        Task<SoftwareReworkRequest> Update(SoftwareReworkRequest request);
        /// <summary>
        /// Метод удаления записи заявки на доработку программного обеспечения
        /// </summary>
        /// <param name="request">Запись заявки на доработку программного обеспечения</param>
        /// <returns></returns>
        Task Delete(SoftwareReworkRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на доработку программного обеспечения
        /// </summary>
        /// <returns>Возвращает список записей заявки на доработку программного обеспечения</returns>
        Task<List<SoftwareReworkRequest>> GetRequests();
    }
}
