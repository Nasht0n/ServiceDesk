using BusinessLogic.Abstract;
using Domain.Views;
using Repository.Abstract;
using System;
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

        public async Task<List<RefillRequestJournal>> GetJournal(DateTime start, DateTime end, bool descending = true)
        {
            var journal = await repository.GetJournals();

            journal = journal.Where(j => j.CreateDate.Date >= start.Date && j.CreateDate <=end.Date).ToList();

            if (descending) return journal.OrderByDescending(j => j.Id).ToList();
            else return journal.OrderBy(j => j.Id).ToList();
        }
    }
}
