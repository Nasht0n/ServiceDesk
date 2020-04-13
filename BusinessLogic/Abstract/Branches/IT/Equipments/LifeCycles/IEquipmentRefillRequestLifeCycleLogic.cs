using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentRefillRequestLifeCycleLogic
    {
        Task<EquipmentRefillRequestLifeCycle> Add(EquipmentRefillRequestLifeCycle lifeCycle);
        Task<List<EquipmentRefillRequestLifeCycle>> GetLifeCycles(int requestId);
    }
}
