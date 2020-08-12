using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IRefillRequestConsumptionRepository
    {
        /// <summary>
        /// Метод получения списка списания расходных материалов
        /// </summary>
        /// <returns>Возвращает список списания расходных материалов</returns>
        Task<List<RefillRequestConsumption>> GetConsumptions();
    }
}
