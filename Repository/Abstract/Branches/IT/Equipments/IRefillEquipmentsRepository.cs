using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заправляемой техники
    /// </summary>
    public interface IRefillEquipmentsRepository
    {
        /// <summary>
        /// Метод добавления записи заправляемой техники
        /// </summary>
        /// <param name="request">Запись заправляемой техники</param>
        /// <returns>Возвращает объект заправляемой техники</returns>
        Task<RefillEquipments> Add(RefillEquipments refill);
        /// <summary>
        /// Метод редактировния записи заправляемой техники
        /// </summary>
        /// <param name="request">Запись заправляемой техники</param>
        /// <returns>Возвращает объект заправляемой техники</returns>
        Task<RefillEquipments> Update(RefillEquipments refill);
        /// <summary>
        /// Метод удаления записи заправляемой техники
        /// </summary>
        /// <param name="request">Запись заправляемой техники</param>
        /// <returns></returns>
        Task Delete(RefillEquipments refill);
        /// <summary>
        /// Метод получения списка записей заправляемой техники
        /// </summary>
        /// <returns>Возвращает список записей заправляемой техники</returns>
        Task<List<RefillEquipments>> GetRefills();
    }
}
