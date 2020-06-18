using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу областей заявок
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Метод добавления области заявки
        /// </summary>
        /// <param name="branch">Область заявки</param>
        /// <returns>Возвращает объект области заявки</returns>
        Task<Branch> AddBranch(Branch branch);
        /// <summary>
        /// Метод редактирования области заявки
        /// </summary>
        /// <param name="branch">Область заявки</param>
        /// <returns>Возвращает область заявки</returns>
        Task<Branch> UpdateBranch(Branch branch);
        /// <summary>
        /// Метод удаления области заявки
        /// </summary>
        /// <param name="branch">Область заявки</param>
        /// <returns></returns>
        Task DeleteBranch(Branch branch);
        /// <summary>
        /// Метод получения списка областей заявок
        /// </summary>
        /// <returns>Возвращает список областей заявок</returns>
        Task<List<Branch>> GetBranches();
    }
}
