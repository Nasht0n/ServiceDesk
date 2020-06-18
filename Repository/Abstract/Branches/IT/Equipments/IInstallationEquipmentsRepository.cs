using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу устанавливаемого оборудования
    /// </summary>
    public interface IInstallationEquipmentsRepository
    {
        /// <summary>
        /// Метод добавления записи устанавливаемого оборудования
        /// </summary>
        /// <param name="request">Запись устанавливаемого оборудования</param>
        /// <returns>Возвращает объект устанавливаемого оборудования</returns>
        Task<InstallationEquipments> Add(InstallationEquipments installation);
        /// <summary>
        /// Метод редактировния записи устанавливаемого оборудования
        /// </summary>
        /// <param name="request">Запись устанавливаемого оборудования</param>
        /// <returns>Возвращает объект устанавливаемого оборудования</returns>
        Task<InstallationEquipments> Update(InstallationEquipments installation);
        /// <summary>
        /// Метод удаления записи устанавливаемого оборудования
        /// </summary>
        /// <param name="request">Запись устанавливаемого оборудования</param>
        /// <returns></returns>
        Task Delete(InstallationEquipments installation);
        /// <summary>
        /// Метод получения списка записей устанавливаемого оборудования
        /// </summary>
        /// <returns>Возвращает список записей устанавливаемого оборудования</returns>
        Task<List<InstallationEquipments>> GetEquipments();
    }
}
