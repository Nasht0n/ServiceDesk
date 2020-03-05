namespace Domain.Models.Requests.Equipment
{
    public class ReplaceComponents
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int ComponentId { get; set; }
        public Component Component { get; set; }

        public int RequestId { get; set; }
        public ComponentReplaceRequest Request { get; set; }
    }
}
