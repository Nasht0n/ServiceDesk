using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу сотрудников групп исполнителей
    /// </summary>
    public interface IExecutorGroupMembersRepository
    {
        /// <summary>
        /// Метод добавления сотрудника в группу исполнителей
        /// </summary>
        /// <param name="member">Данные о сотруднике и группе исполнителей</param>
        /// <returns>Возвращает добавленную запись сотрудника в группу исполнителей</returns>
        Task<ExecutorGroupMember> AddExecutorGroupMember(ExecutorGroupMember member);
        /// <summary>
        /// Метод удаления сотрудника из группы исполнителей
        /// </summary>
        /// <param name="member">Данные о сотруднике и группе исполнителей</param>
        /// <returns></returns>
        Task DeleteExecutorGroupMember(ExecutorGroupMember member);
        /// <summary>
        /// Метод получения списка сотрудников в группах исполнителей
        /// </summary>
        /// <returns>Возвращает список сотрудников в группах исполнителей</returns>
        Task<List<ExecutorGroupMember>> GetGroupMembers();
    }
}
