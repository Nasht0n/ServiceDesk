using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Consumptions
{
    /// <summary>
    /// Интерфейс доступа к затраченным расходным материалам
    /// </summary>
    public interface IEquipmentRefillRequestConsumptionRepository
    {
        /// <summary>
        /// Метод добавления данных о затратах расходного материала на заправку оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на заправку оборудования</param>
        /// <returns>Возвращаем объект затраченных расходных материалов на заправку оборудования</returns>
        Task<EquipmentRefillRequestConsumption> Add(EquipmentRefillRequestConsumption consumption);
        /// <summary>
        /// Метод редактирования данных о затратах расходного материала на заправку оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на заправку оборудования</param>
        /// <returns>Возвращаем объект затраченных расходных материалов на заправку оборудования</returns>
        Task<EquipmentRefillRequestConsumption> Update(EquipmentRefillRequestConsumption consumption);
        /// <summary>
        /// Метод удаления данных о затратах расходного материала на заправку оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на заправку оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentRefillRequestConsumption consumption);
        /// <summary>
        /// Метод получения списка затрат расходных материалов на заправку оборудования
        /// </summary>
        /// <returns>Возврат списка затрат расходных материалов на заправку оборудования</returns>
        Task<List<EquipmentRefillRequestConsumption>> GetRequestConsumptions();
    }
}
