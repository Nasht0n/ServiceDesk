using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу групп исполнителей закрепленных за видом заявок
    /// </summary>
    public interface IServicesExecutorGroupsRepository
    {
        /// <summary>
        /// Метод закрепления группы исполнителей за видом заявки
        /// </summary>
        /// <param name="servicesExecutorGroup">Запись закрепления группы исполнителей за видом заявки</param>
        /// <returns>Возвращает объект закрепленния группы исполнителей за видом заявки</returns>
        Task<ServicesExecutorGroup> Add(ServicesExecutorGroup servicesExecutorGroup);
        /// <summary>
        /// Метод удаления записи закрепления группы исполнителей за видом заявки
        /// </summary>
        /// <param name="servicesExecutorGroup">Удаляемая запись закрепления группы исполнителей за видом заявки</param>
        /// <returns></returns>
        Task Delete(ServicesExecutorGroup servicesExecutorGroup);
        /// <summary>
        /// Метод получения списка закрепленных групп исполнителей за видами заявок
        /// </summary>
        /// <returns>Возвращает список закрепленных групп исполнителей за видами заявок</returns>
        Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups();
    }
}
