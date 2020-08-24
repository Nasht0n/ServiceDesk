using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.Consumptions
{
    /// <summary>
    /// Интерфейс доступа к затраченным расходным материалам
    /// </summary>
    public interface IEquipmentRepairRequestConsumptionRepository
    {
        /// <summary>
        /// Метод добавления данных о затратах расходного материала на ремонт оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на ремонт оборудования</param>
        /// <returns>Возвращаем объект затраченных расходных материалов на ремонт оборудования</returns>
        Task<EquipmentRepairRequestConsumption> Add(EquipmentRepairRequestConsumption consumption);
        /// <summary>
        /// Метод редактирования данных о затратах расходного материала на ремонт оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на ремонт оборудования</param>
        /// <returns>Возвращаем объект затраченных расходных материалов на ремонт оборудования</returns>
        Task<EquipmentRepairRequestConsumption> Update(EquipmentRepairRequestConsumption consumption);
        /// <summary>
        /// Метод удаления данных о затратах расходного материала на ремонт оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на ремонт оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentRepairRequestConsumption consumption);
        /// <summary>
        /// Метод получения списка затрат расходных материалов на ремонт оборудования
        /// </summary>
        /// <returns>Возврат списка затрат расходных материалов на ремонт оборудования</returns>
        Task<List<EquipmentRepairRequestConsumption>> GetRequestConsumptions();
    }
}
