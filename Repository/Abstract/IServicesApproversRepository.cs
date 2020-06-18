using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу данных пользователей, имеющих право согласования заявок, закрепленных за определенным видом заявок
    /// </summary>
    public interface IServicesApproversRepository
    {
        /// <summary>
        /// Метод добавления записи закрепления пользователя, имеющего право согласования заявок, за видом заявки
        /// </summary>
        /// <param name="approver">Добавляемая запись закрепления</param>
        /// <returns>Объект пользователя закрепленного за видом заявки, для согласования</returns>
        Task<ServicesApprover> AddServicesApprover(ServicesApprover approver);
        /// <summary>
        /// Метод удаления записи закрепления пользователя за видом заявки, для согласования
        /// </summary>
        /// <param name="approver">Удаляемая запись закрепления</param>
        /// <returns></returns>
        Task DeleteServicesApprover(ServicesApprover approver);
        /// <summary>
        /// Метод получения списка пользователей закрепленных за видами заявок для согласования
        /// </summary>
        /// <returns>Возвращает список пользователей закрепленных за видами заявок для согласования</returns>
        Task<List<ServicesApprover>> GetServicesApprovers();
    }
}
