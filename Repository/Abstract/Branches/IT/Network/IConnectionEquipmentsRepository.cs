using Domain.Models.Requests.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Network
{
    /// <summary>
    /// Интерфейс доступа к хранилищу подключаемого оборудования к ЛВС
    /// </summary>
    public interface IConnectionEquipmentsRepository
    {
        /// <summary>
        /// Метод добавления записи подключаемого оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись подключаемого оборудования к ЛВС</param>
        /// <returns>Возвращает объект подключаемого оборудования к ЛВС</returns>
        Task<ConnectionEquipments> Add(ConnectionEquipments equipments);
        /// <summary>
        /// Метод редактировния записи подключаемого оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись подключаемого оборудования к ЛВС</param>
        /// <returns>Возвращает объект подключаемого оборудования к ЛВС</returns>
        Task<ConnectionEquipments> Update(ConnectionEquipments equipments);
        /// <summary>
        /// Метод удаления записи подключаемого оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись подключаемого оборудования к ЛВС</param>
        /// <returns></returns>
        Task Delete(ConnectionEquipments equipments);
        /// <summary>
        /// Метод получения списка записей подключаемого оборудования к ЛВС
        /// </summary>
        /// <returns>Возвращает список записей подключаемого оборудования к ЛВС</returns>
        Task<List<ConnectionEquipments>> GetEquipments();
    }
}
