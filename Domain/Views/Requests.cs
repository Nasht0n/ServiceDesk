using Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Views
{
    [Table("dbo.RequestsView")]
    public class Requests
    {
        [Key]
        public long? RowNumber { get; set; }

        public int RequestId { get; set; }

        public string Title { get; set; }

        public string Justification { get; set; }

        public string Description { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        
        public int ClientId { get; set; }
        public Employee Client { get; set; }

        public int? ExecutorId { get; set; }
        public Employee Executor { get; set; }

        public int ExecutorGroupId { get; set; }
        public ExecutorGroup ExecutorGroup { get; set; }
        public int SubdivisionId { get; set; }
        public Subdivision Subdivision { get; set; }
        public DateTime Date { get; set; }

        public string Source { get; set; }
    }
}
