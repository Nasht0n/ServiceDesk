using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заменяемого оборудования
    /// </summary>
    public interface IReplaceEquipmentsRepository
    {
        /// <summary>
        /// Метод добавления записи заменяемого оборудования
        /// </summary>
        /// <param name="request">Запись заменяемого оборудования</param>
        /// <returns>Возвращает объект заменяемого оборудования</returns>
        Task<ReplaceEquipments> Add(ReplaceEquipments equipments);
        /// <summary>
        /// Метод редактировния записи заменяемого оборудования
        /// </summary>
        /// <param name="request">Запись заменяемого оборудования</param>
        /// <returns>Возвращает объект заменяемого оборудования</returns>
        Task<ReplaceEquipments> Update(ReplaceEquipments equipments);
        /// <summary>
        /// Метод удаления записи заменяемого оборудования
        /// </summary>
        /// <param name="request">Запись заменяемого оборудования</param>
        /// <returns></returns>
        Task Delete(ReplaceEquipments equipments);
        /// <summary>
        /// Метод получения списка записей заменяемого оборудования
        /// </summary>
        /// <returns>Возвращает список записей заменяемого оборудования</returns>
        Task<List<ReplaceEquipments>> GetEquipments();
    }
}
