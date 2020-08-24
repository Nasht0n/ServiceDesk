using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests.Equipment
{
    /// <summary>
    /// Расход материалов на ремонт техники 
    /// </summary>
    public class EquipmentRepairRequestConsumption
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Идентификатор расходника
        /// </summary>
        public int ConsumableId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        public EquipmentRepairRequest Request { get; set; }
        public Consumable Consumable { get; set; }
    }
}
