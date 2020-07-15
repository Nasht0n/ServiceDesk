using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IUnitLogic
    {
        Task<Unit> Save(Unit unit);
        Task Delete(Unit unit);
        Task<Unit> GetUnit(int id);
        Task<List<Unit>> GetUnits(bool descendings = false);
    }
}
