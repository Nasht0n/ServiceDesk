using Domain.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRefillRequestJournalLogic
    {
        Task<List<RefillRequestJournal>> GetJournal(bool descending = true);
        Task<List<RefillRequestJournal>> GetJournal(DateTime start, DateTime end, bool descending = true);
    }
}
