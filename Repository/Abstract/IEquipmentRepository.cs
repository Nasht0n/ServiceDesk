using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IEquipmentRepository
    {
        Task<Equipment> Add(Equipment equipment);
        Task<Equipment> Update(Equipment equipment);
        Task Delete(Equipment equipment);
        Task<List<Equipment>> GetEquipments();
    }
}
