using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на замену оборудования
    /// </summary>
    public interface IEquipmentReplaceRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на замену оборудования
        /// </summary>
        /// <param name="request">Запись заявки на замену оборудования</param>
        /// <returns>Возвращает объект заявки на замену оборудования</returns>
        Task<EquipmentReplaceRequest> Add(EquipmentReplaceRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на замену оборудования
        /// </summary>
        /// <param name="request">Запись заявки на замену оборудования</param>
        /// <returns>Возвращает объект заявки на замену оборудования</returns>
        Task<EquipmentReplaceRequest> Update(EquipmentReplaceRequest request);
        /// <summary>
        /// Метод удаления записи заявки на замену оборудования
        /// </summary>
        /// <param name="request">Запись заявки на замену оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentReplaceRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на замену оборудования
        /// </summary>
        /// <returns>Возвращает список записей заявки на замену оборудования</returns>
        Task<List<EquipmentReplaceRequest>> GetRequests();
    }
}
