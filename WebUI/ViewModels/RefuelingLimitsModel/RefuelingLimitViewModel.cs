using WebUI.ViewModels.SubdivisionModel;

namespace WebUI.ViewModels.RefuelingLimitsModel
{
    public class RefuelingLimitViewModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
        public SubdivisionViewModel SubdivisionModel { get; set; }
    }
}