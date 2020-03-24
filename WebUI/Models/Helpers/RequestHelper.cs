using BusinessLogic;
using Domain.Models;
using System.Linq;

namespace WebUI.Models.Helpers
{
    public static class RequestHelper
    {      
        public static ExecutorGroup GetExecutorGroup(Service service)
        {
            // Получение списка групп исполнителей вида работы
            var serviceContractor = service.ExecutorGroups.ToList();
            // если группа найдена возвращаем группу исполнителей
            if (serviceContractor.Count != 0) return serviceContractor[0].ExecutorGroup;
            else return null;
        }

        public static Employee GetExecutor(Employee employee, ExecutorGroup group, SubdivisionService subdvisionService, EmployeeService employeeService)
        {
            // Получение подразделения сотрудника
            var subdivision = subdvisionService.GetSubdivisionById(employee.SubdivisionId);
            // Получение списка исполнителей закрепленных за подразделением            
            var subdivisionContractor = subdivision.SubdivisionExecutors.ToList();
            // исполнитель
            Employee result = null;
            // счетчик
            int counter = 0;
            // проход по всем исполнителям закрепленным за подразделением
            foreach (var emp in subdivisionContractor)
            {
                var current = employeeService.GetEmployeeById(emp.Id);
                // Если исполнитель относится к группе исполнителей данного вида работ
                if (current.ExecutorGroups.Any(eg => eg.ExecutorGroupId == group.Id))
                {
                    // увеличиваем счетчит
                    counter++;
                    // инициализируем результат
                    result = current;
                }
            }
            // если исполнителей больше чем 1
            // исполнитель не определен
            if (counter > 1)
            {
                return null;
            }
            // иначе возвращаем исполнителя
            else
            {
                return result;
            }
        }
    }
}