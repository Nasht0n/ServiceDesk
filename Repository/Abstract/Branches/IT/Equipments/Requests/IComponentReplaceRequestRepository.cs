using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на замену комплектующего оборудования
    /// </summary>
    public interface IComponentReplaceRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на замену комплектующего оборудования
        /// </summary>
        /// <param name="request">Запись заявки на замену комплектующего оборудования</param>
        /// <returns>Возвращает объект заявки на замену комплектующего оборудования</returns>
        Task<ComponentReplaceRequest> Add(ComponentReplaceRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на замену комплектующего оборудования
        /// </summary>
        /// <param name="request">Запись заявки на замену комплектующего оборудования</param>
        /// <returns>Возвращает объект заявки на замену комплектующего оборудования</returns>
        Task<ComponentReplaceRequest> Update(ComponentReplaceRequest request);
        /// <summary>
        /// Метод удаления записи заявки на замену комплектующего оборудования
        /// </summary>
        /// <param name="request">Запись заявки на замену комплектующего оборудования</param>
        /// <returns></returns>
        Task Delete(ComponentReplaceRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на замену комплектующего оборудования
        /// </summary>
        /// <returns>Возвращает список записей заявки на замену комплектующего оборудования</returns>
        Task<List<ComponentReplaceRequest>> GetRequests();
    }
}
