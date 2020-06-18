using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу групп исполнителей
    /// </summary>
    public interface IExecutorGroupRepository
    {
        /// <summary>
        /// Метод добавления группы исполнителей
        /// </summary>
        /// <param name="group">Запись группы исполнителей</param>
        /// <returns>Возвращает объект группы исполнителей</returns>
        Task<ExecutorGroup> AddExecutorGroup(ExecutorGroup group);
        /// <summary>
        /// Метод обновления группы исполнителей
        /// </summary>
        /// <param name="group">Запись группы исполнителей</param>
        /// <returns>Возвращает объект группы исполнителей</returns>
        Task<ExecutorGroup> UpdateExecutorGroup(ExecutorGroup group);
        /// <summary>
        /// Метод удаления группы исполнителей
        /// </summary>
        /// <param name="group">Объект группы исполнителей</param>
        /// <returns></returns>
        Task DeleteExecutorGroup(ExecutorGroup group);
        /// <summary>
        /// Метод получения списка групп исполнителей
        /// </summary>
        /// <returns>Возвращает список групп исполнителей</returns>
        Task<List<ExecutorGroup>> GetExecutorGroups();
    }
}
