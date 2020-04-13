using WebUI.ViewModels.ComponentModel;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class ReplaceComponentViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ComponentId { get; set; }
        public int RequestId { get; set; }
        public ComponentReplaceRequestViewModel RequestModel { get; set; }
        public ComponentViewModel ComponentModel { get; set; }
    }
}