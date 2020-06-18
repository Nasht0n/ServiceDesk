using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу ремонтируемой техники
    /// </summary>
    public interface IRepairEquipmentsRepository
    {
        /// <summary>
        /// Метод добавления записи ремонтируемой техники
        /// </summary>
        /// <param name="request">Запись ремонтируемой техники</param>
        /// <returns>Возвращает объект ремонтируемой техники</returns>
        Task<RepairEquipments> Add(RepairEquipments repair);
        /// <summary>
        /// Метод редактировния записи ремонтируемой техники
        /// </summary>
        /// <param name="request">Запись ремонтируемой техники</param>
        /// <returns>Возвращает объект ремонтируемой техники</returns>
        Task<RepairEquipments> Update(RepairEquipments repair);
        /// <summary>
        /// Метод удаления записи ремонтируемой техники
        /// </summary>
        /// <param name="request">Запись ремонтируемой техники</param>
        /// <returns></returns>
        Task Delete(RepairEquipments repair);
        /// <summary>
        /// Метод получения списка записей ремонтируемой техники
        /// </summary>
        /// <returns>Возвращает список записей ремонтируемой техники</returns>
        Task<List<RepairEquipments>> GetRepairs();
    }
}
