using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRefillRequestJournalLogic
    {
        Task<List<RefillRequestJournal>> GetJournal(bool descending = true);
    }
}
