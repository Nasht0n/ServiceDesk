using Domain.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Views
{
    public interface IRepairRequestJournalLogic
    {
        Task<List<RepairRequestJournal>> GetJournal(bool descending = true);
        Task<List<RepairRequestJournal>> GetJournal(DateTime start, DateTime end, bool descending = true);
    }
}
