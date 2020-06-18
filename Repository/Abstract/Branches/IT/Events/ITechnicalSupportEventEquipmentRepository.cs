using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events
{
    /// <summary>
    /// Интерфейс доступа к хранилищу оборудования устанавливаемого на мероприятии
    /// </summary>
    public interface ITechnicalSupportEventEquipmentRepository
    {
        /// <summary>
        /// Метод добавления записи оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <param name="request">Запись оборудования устанавливаемого на мероприятии</param>
        /// <returns>Возвращает объект оборудования устанавливаемого на мероприятии</returns>
        Task<TechnicalSupportEventEquipments> Add(TechnicalSupportEventEquipments equipments);
        /// <summary>
        /// Метод редактировния записи оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <param name="request">Запись оборудования устанавливаемого на мероприятии</param>
        /// <returns>Возвращает объект оборудования устанавливаемого на мероприятии</returns>
        Task<TechnicalSupportEventEquipments> Update(TechnicalSupportEventEquipments equipments);
        /// <summary>
        /// Метод удаления записи оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <param name="request">Запись оборудования устанавливаемого на мероприятии</param>
        /// <returns></returns>
        Task Delete(TechnicalSupportEventEquipments equipments);
        /// <summary>
        /// Метод получения списка записей оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <returns>Возвращает список записей оборудования устанавливаемого на мероприятии</returns>
        Task<List<TechnicalSupportEventEquipments>> GetEquipments();
    }
}
