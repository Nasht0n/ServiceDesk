using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Views
{
    [Table("dbo.JournalRefillRequestView")]
    public class RefillRequestJournal
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Subdivision { get; set; }
        public string Campus { get; set; }
        public string Location { get; set; }
        public string ClientFullname { get; set; }
        public string Title { get; set; }
        public string InventoryNumber { get; set; }
        public string ExecutorFullname { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}
