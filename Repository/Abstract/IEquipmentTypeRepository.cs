using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Класс доступа к хранилищу типов оборудования
    /// </summary>
    public interface IEquipmentTypeRepository
    {
        /// <summary>
        /// Метод добавления типа оборудования
        /// </summary>
        /// <param name="equipmentType">Запись типа оборудования</param>
        /// <returns>Возвращает объект типа оборудования</returns>
        Task<EquipmentType> Add(EquipmentType equipmentType);
        /// <summary>
        /// Метод обновления типа оборудования
        /// </summary>
        /// <param name="equipmentType">Запись типа оборудования</param>
        /// <returns>Возвращает объект типа оборудования</returns>
        Task<EquipmentType> Update(EquipmentType equipmentType);
        /// <summary>
        /// Метод удаления типа оборудования
        /// </summary>
        /// <param name="equipmentType">Запись типа оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentType equipmentType);
        /// <summary>
        /// Метод получения списка типов оборудования
        /// </summary>
        /// <returns>Возвращает список типов оборудования</returns>
        Task<List<EquipmentType>> GetEquipmentTypes();
    }
}
