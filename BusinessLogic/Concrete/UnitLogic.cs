using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessLogic.Concrete
{
    public class UnitLogic : IUnitLogic
    {
        private readonly IUnitRepository repository;

        public UnitLogic(IUnitRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(Unit unit)
        {
            await repository.Delete(unit);
        }

        public async Task<Unit> GetUnit(int id)
        {
            var units = await repository.GetUnits();
            return units.FirstOrDefault(u => u.Id == id);
        }

        public async Task<List<Unit>> GetUnits(bool descendings = false)
        {
            var units = await repository.GetUnits();
            if (descendings) return units.OrderBy(u => u.Fullname).ToList();
            else return units.OrderByDescending(u => u.Fullname).ToList();
        }

        public async Task<Unit> Save(Unit unit)
        {
            if (unit.Id == 0) return await repository.Add(unit);
            else return await repository.Update(unit);
        }
    }
}
