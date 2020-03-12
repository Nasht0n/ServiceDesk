using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ConsumableService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<Consumable> GetConsumables()
        {
            return serviceDesk.ConsumableRepository.Get().ToList();
        }

        public Consumable GetConsumableById(int id)
        {
            return serviceDesk.ConsumableRepository.Get(filter: e => e.Id == id).FirstOrDefault();
        }

        public void AddConsumable(Consumable consumable)
        {
            serviceDesk.ConsumableRepository.Insert(consumable);
            serviceDesk.Save();
        }

        public void UpdateConsumable(Consumable consumable)
        {
            serviceDesk.ConsumableRepository.Update(consumable);
            serviceDesk.Save();
        }

        public void DeleteConsumable(Consumable consumable)
        {
            serviceDesk.ConsumableRepository.Delete(consumable);
            serviceDesk.Save();
        }

    }
}
