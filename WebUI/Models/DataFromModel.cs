using Domain.Models;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.Subdivision;

namespace WebUI.Models
{
    public class DataFromModel
    {
        public static Subdivision GetData(SubdivisionViewModel model)
        {
            return new Subdivision
            {
                Id = model.Id,
                Fullname = model.Fullname,
                Shortname = model.Shortname
            };
        }

        internal static Employee GetData(EmployeeViewModel model)
        {
            return new Employee
            {
                Id = model.Id,
                Surname = model.Surname,
                Firstname = model.Firstname,
                Patronymic = model.Patronymic,
                Post = model.Post,
                Email = model.Email,
                Phone = model.Phone,
                HeadOfUnit = model.HeadOfUnit,
                SubdivisionId = model.SubdivisionModel.Id,
                Subdivision = GetData(model.SubdivisionModel)
            };
        }
    }
}