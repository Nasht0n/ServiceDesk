namespace WebUI.ViewModels.Requests.IT
{
    public abstract class DetailsRequestViewModel
    {
        public string Message { get; set; }
        public bool IsApprovers { get; set; }
        public bool IsExecutor { get; set; }
        public bool IsClient { get; set; }
    }
}