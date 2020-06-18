using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на заправку техники
    /// </summary>
    public interface IEquipmentRefillRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на заправку техники
        /// </summary>
        /// <param name="request">Запись заявки на заправку техники</param>
        /// <returns>Возвращает объект заявки на заправку техники</returns>
        Task<EquipmentRefillRequest> Add(EquipmentRefillRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на заправку техники
        /// </summary>
        /// <param name="request">Запись заявки на заправку техники</param>
        /// <returns>Возвращает объект заявки на заправку техники</returns>
        Task<EquipmentRefillRequest> Update(EquipmentRefillRequest request);
        /// <summary>
        /// Метод удаления записи заявки на заправку техники
        /// </summary>
        /// <param name="request">Запись заявки на заправку техники</param>
        /// <returns></returns>
        Task Delete(EquipmentRefillRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на заправку техники
        /// </summary>
        /// <returns>Возвращает список записей заявки на заправку техники</returns>
        Task<List<EquipmentRefillRequest>> GetRequests();
    }
}
