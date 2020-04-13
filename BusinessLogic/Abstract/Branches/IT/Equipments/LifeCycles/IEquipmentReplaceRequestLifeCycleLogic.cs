using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles
{
    public interface IEquipmentReplaceRequestLifeCycleLogic
    {
        Task<EquipmentReplaceRequestLifeCycle> Add(EquipmentReplaceRequestLifeCycle lifeCycle);
        Task<List<EquipmentReplaceRequestLifeCycle>> GetLifeCycles(int requestId);
    }
}
