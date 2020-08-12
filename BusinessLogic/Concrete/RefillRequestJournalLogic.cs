using BusinessLogic.Abstract;
using Domain.Views;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class RefillRequestJournalLogic : IRefillRequestJournalLogic
    {
        private readonly IRefillRequestJournalRepository repository;

        public RefillRequestJournalLogic(IRefillRequestJournalRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<RefillRequestJournal>> GetJournal(bool descending = true)
        {
            var journal = await repository.GetJournals();
            if (descending) return journal.OrderByDescending(j => j.Id).ToList();
            else return journal.OrderBy(j => j.Id).ToList();
        }
    }
}
