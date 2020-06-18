using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    /// <summary>
    /// Класс доступа к хранилищу заявок на установку оборудования
    /// </summary>
    public interface IEquipmentInstallationRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на установку оборудования
        /// </summary>
        /// <param name="request">Запись заявки на установку оборудования</param>
        /// <returns>Возвращает объект заявки на установку оборудования</returns>
        Task<EquipmentInstallationRequest> Add(EquipmentInstallationRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на установку оборудования
        /// </summary>
        /// <param name="request">Запись заявки на установку оборудования</param>
        /// <returns>Возвращает объект заявки на установку оборудования</returns>
        Task<EquipmentInstallationRequest> Update(EquipmentInstallationRequest request);
        /// <summary>
        /// Метод удаления записи заявки на установку оборудования
        /// </summary>
        /// <param name="request">Запись заявки на установку оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentInstallationRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на установку оборудования
        /// </summary>
        /// <returns>Возвращает список записей заявки на установку оборудования</returns>
        Task<List<EquipmentInstallationRequest>> GetRequests();
    }
}
