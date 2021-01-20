using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software
{
    /// <summary>
    /// Интерфейс доступа к Данным заголовкам страниц сайта
    /// </summary>
    public interface IInformationStatusRequestTitlesRepository
    {
        /// <summary>
        /// Метод добавления записи заголовка страницы сайта
        /// </summary>
        /// <param name="title">Запись заголовка страницы сайта</param>
        /// <returns>Возвращает объект заголовка страницы сайта</returns>
        Task<InformationStatusRequestTitle> Add(InformationStatusRequestTitle title);
        /// <summary>
        /// Метод редактировния записи заголовка страницы сайта
        /// </summary>
        /// <param name="title">Запись заголовка страницы сайта</param>
        /// <returns>Возвращает объект заголовка страницы сайта</returns>
        Task<InformationStatusRequestTitle> Update(InformationStatusRequestTitle title);
        /// <summary>
        /// Метод удаления записи заголовка страницы сайта
        /// </summary>
        /// <param name="title">Запись заголовка страницы сайта</param>
        /// <returns></returns>
        Task Delete(InformationStatusRequestTitle title);
        /// <summary>
        /// Метод получения списка записей заголовка страницы сайта
        /// </summary>
        /// <returns>Возвращает список записей заголовка страницы сайта</returns>
        Task<List<InformationStatusRequestTitle>> GetTitles();
    }
}
