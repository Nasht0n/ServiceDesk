namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrunchId { get; set; }
        public Brunch Brunch { get; set; }
    }
}
