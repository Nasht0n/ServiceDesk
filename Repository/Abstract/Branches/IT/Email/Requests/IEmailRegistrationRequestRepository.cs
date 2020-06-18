using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на регистрацию электронной почты
    /// </summary>
    public interface IEmailRegistrationRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на регистрацию электронной почты
        /// </summary>
        /// <param name="request">Запись заявки на регистрацию электронной почты</param>
        /// <returns>Возвращает объект заявки на регистрацию электронной почты</returns>
        Task<EmailRegistrationRequest> Add(EmailRegistrationRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на регистрацию электронной почты
        /// </summary>
        /// <param name="request">Запись заявки на регистрацию электронной почты</param>
        /// <returns>Возвращает объект заявки на регистрацию электронной почты</returns>
        Task<EmailRegistrationRequest> Update(EmailRegistrationRequest request);
        /// <summary>
        /// Метод удаления записи заявки на регистрацию электронной почты
        /// </summary>
        /// <param name="request">Запись заявки на регистрацию электронной почты</param>
        /// <returns></returns>
        Task Delete(EmailRegistrationRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на регистрацию электронной почты
        /// </summary>
        /// <returns>Возвращает список записей заявки на регистрацию электронной почты</returns>
        Task<List<EmailRegistrationRequest>> GetRequests();
    }
}
