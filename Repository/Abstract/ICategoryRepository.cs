using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу категорий заявок
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Метод добавления категории заявок
        /// </summary>
        /// <param name="category">Категория заявок</param>
        /// <returns>Возвращает объект добавленной категории заявки</returns>
        Task<Category> AddCategory(Category category);
        /// <summary>
        /// Метод редактирования категории заявок
        /// </summary>
        /// <param name="category">Категория заявок</param>
        /// <returns>Возвращает объект категории заявок</returns>
        Task<Category> UpdateCategory(Category category);
        /// <summary>
        /// Метод удаления категории заявок
        /// </summary>
        /// <param name="category">Категория заявок</param>
        /// <returns></returns>
        Task DeleteCategory(Category category);
        /// <summary>
        /// Метод получения списка категорий заявок
        /// </summary>
        /// <returns>Получение списка категорий заявок</returns>
        Task<List<Category>> GetCategories();
    }
}
