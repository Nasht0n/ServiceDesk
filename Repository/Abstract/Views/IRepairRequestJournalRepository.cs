using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Views
{
    public interface IRepairRequestJournalRepository
    {
        /// <summary>
        /// Метод получения списка входящей корреспонденции
        /// </summary>
        /// <returns>Возвращает список входящей корреспонденции</returns>
        Task<List<RepairRequestJournal>> GetJournals();
    }
}
