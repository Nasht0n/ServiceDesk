using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на ремонт оборудования
    /// </summary>
    public interface IEquipmentRepairRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на ремонт оборудования
        /// </summary>
        /// <param name="request">Запись заявки на ремонт оборудования</param>
        /// <returns>Возвращает объект заявки на ремонт оборудования</returns>
        Task<EquipmentRepairRequest> Add(EquipmentRepairRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на ремонт оборудования
        /// </summary>
        /// <param name="request">Запись заявки на ремонт оборудования</param>
        /// <returns>Возвращает объект заявки на ремонт оборудования</returns>
        Task<EquipmentRepairRequest> Update(EquipmentRepairRequest request);
        /// <summary>
        /// Метод удаления записи заявки на ремонт оборудования
        /// </summary>
        /// <param name="request">Запись заявки на ремонт оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentRepairRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на ремонт оборудования
        /// </summary>
        /// <returns>Возвращает список записей заявки на ремонт оборудования</returns>
        Task<List<EquipmentRepairRequest>> GetRequests();
    }
}
