using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ManyToMany
{
    public class SubdivisionExecutor
    {
        [Required]
        public int SubdivisionId { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        public Subdivision Subdivision { get; set; }
        public Employee Employee { get; set; }
    }
}
