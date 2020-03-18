using System;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.ExecutorGroup;
using WebUI.ViewModels.Priority;
using WebUI.ViewModels.Service;
using WebUI.ViewModels.Status;
using WebUI.ViewModels.Subdivision;

namespace WebUI.ViewModels.Requests.View
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }
        public string Title { get; set; }
        public string Justification { get; set; }
        public string Description { get; set; }
        public int ServiceId { get; set; }
        public ServiceViewModel ServiceModel { get; set; }
        public int StatusId { get; set; }
        public StatusViewModel StatusModel { get; set; }
        public int PriorityId { get; set; }
        public PriorityViewModel PriorityModel { get; set; }
        public int ClientId { get; set; }
        public EmployeeViewModel ClientModel { get; set; }
        public int ExecutorId { get; set; }
        public EmployeeViewModel ExecutorModel { get; set; }
        public int ExecutorGroupId { get; set; }
        public ExecutorGroupViewModel ExecutorGroupModel { get; set; }
        public int SubdivisionId { get; set; }
        public SubdivisionViewModel SubdivisionModel { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
    }
}