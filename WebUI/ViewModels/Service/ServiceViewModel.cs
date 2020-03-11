using WebUI.ViewModels.Category;

namespace WebUI.ViewModels.Service
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }
        public bool ApprovalRequired { get; set; }
        public string Controller { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel CategoryModel { get; set; }
    }
}