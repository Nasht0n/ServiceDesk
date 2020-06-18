using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу учебных корпусов
    /// </summary>
    public interface ICampusRepository
    {
        /// <summary>
        /// Метод добавления учебного корпуса
        /// </summary>
        /// <param name="campus">Учебный корпус</param>
        /// <returns>Возвращает объект учебного корпуса</returns>
        Task<Campus> Add(Campus campus);
        /// <summary>
        /// Метод редактирования учебного корпуса
        /// </summary>
        /// <param name="campus">Учебный корпус</param>
        /// <returns>Возвращает отредактированный учебный корпус</returns>
        Task<Campus> Update(Campus campus);
        /// <summary>
        /// Метод удаления учебного корпуса
        /// </summary>
        /// <param name="campus">Учебный корпус</param>
        /// <returns></returns>
        Task Delete(Campus campus);
        /// <summary>
        /// Метод получения списка учебных корпусов
        /// </summary>
        /// <returns>Возвращает список учебных корпусов</returns>
        Task<List<Campus>> GetCampuses();
    }
}
