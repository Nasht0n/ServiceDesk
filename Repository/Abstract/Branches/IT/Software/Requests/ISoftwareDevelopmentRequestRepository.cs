using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на разработку программного обеспечения
    /// </summary>
    public interface ISoftwareDevelopmentRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на разработку программного обеспечения
        /// </summary>
        /// <param name="request">Запись заявки на разработку программного обеспечения</param>
        /// <returns>Возвращает объект заявки на разработку программного обеспечения</returns>
        Task<SoftwareDevelopmentRequest> Add(SoftwareDevelopmentRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на разработку программного обеспечения
        /// </summary>
        /// <param name="request">Запись заявки на разработку программного обеспечения</param>
        /// <returns>Возвращает объект заявки на разработку программного обеспечения</returns>
        Task<SoftwareDevelopmentRequest> Update(SoftwareDevelopmentRequest request);
        /// <summary>
        /// Метод удаления записи заявки на разработку программного обеспечения
        /// </summary>
        /// <param name="request">Запись заявки на разработку программного обеспечения</param>
        /// <returns></returns>
        Task Delete(SoftwareDevelopmentRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на разработку программного обеспечения
        /// </summary>
        /// <returns>Возвращает список записей заявки на разработку программного обеспечения</returns>
        Task<List<SoftwareDevelopmentRequest>> GetRequests();
    }
}
