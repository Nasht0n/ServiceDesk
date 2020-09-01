using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Views
{
    [Table("dbo.JournalRepairRequestView")]
    public class RepairRequestJournal
    {
        [Key]
        public long? Id { get; set; }
        public int RequestId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Subdivision { get; set; }
        public string Campus { get; set; }
        public string Location { get; set; }
        public string Client { get; set; }
        public string Title { get; set; }
        public string InventoryNumber { get; set; }
        public string Executor { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}
