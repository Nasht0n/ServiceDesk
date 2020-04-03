using Domain.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEquipmentTypeLogic
    {
        Task<EquipmentType> GetEquipmentTypeById(int id);
    }
}
