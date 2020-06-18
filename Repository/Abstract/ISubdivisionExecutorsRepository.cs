using Domain.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу исполнителей закрепленных за подразделением
    /// </summary>
    public interface ISubdivisionExecutorsRepository
    {
        /// <summary>
        /// Метод закрепления исполнителя за подразделением
        /// </summary>
        /// <param name="subdivisionExecutor">Запись закрепления исполнителя за подразделением</param>
        /// <returns>Возвращает объект закрепления исполнителя за подразделением</returns>
        Task<SubdivisionExecutor> AddSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor);
        /// <summary>
        /// Метод удаления закрепления исполнителя за подразделением
        /// </summary>
        /// <param name="subdivisionExecutor">Объект закрепления исполнителя за подразделением</param>
        /// <returns></returns>
        Task DeleteSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor);
        /// <summary>
        /// Метод получения списка исполнителей закрепленных за подразделением
        /// </summary>
        /// <returns>Возвращает список исполнителей закрепленных за подразделением</returns>
        Task<List<SubdivisionExecutor>> GetSubdivisionExecutors();
    }
}
