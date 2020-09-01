using BusinessLogic.Abstract.Views;
using Domain.Views;
using Repository.Abstract.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Views
{
    public class RepairRequestJournalLogic : IRepairRequestJournalLogic
    {
        private readonly IRepairRequestJournalRepository repository;

        public RepairRequestJournalLogic(IRepairRequestJournalRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<RepairRequestJournal>> GetJournal(bool descending = true)
        {
            var journal = await repository.GetJournals();
            if (descending) return journal.OrderByDescending(j => j.Id).ToList();
            else return journal.OrderBy(j => j.Id).ToList();
        }

        public async Task<List<RepairRequestJournal>> GetJournal(DateTime start, DateTime end, bool descending = true)
        {
            var journal = await repository.GetJournals();
            journal = journal.Where(j => j.CreateDate.Date >= start.Date && j.CreateDate <= end.Date).ToList();
            if (descending) return journal.OrderByDescending(j => j.Id).ToList();
            else return journal.OrderBy(j => j.Id).ToList();
        }
    }
}
