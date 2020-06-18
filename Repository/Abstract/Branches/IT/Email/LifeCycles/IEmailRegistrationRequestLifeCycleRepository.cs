using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на регистрацию электронной почты
    /// </summary>
    public interface IEmailRegistrationRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на регистрацию электронной почты
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на регистрацию электронной почты</param>
        /// <returns>Возвращает объект жизненного цикла заявки на регистрацию электронной почты</returns>
        Task<EmailRegistrationRequestLifeCycle> Add(EmailRegistrationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на регистрацию электронной почты
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на регистрацию электронной почты</param>
        /// <returns>Возвращает объект жизненного цикла заявки на регистрацию электронной почты</returns>
        Task<EmailRegistrationRequestLifeCycle> Update(EmailRegistrationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на регистрацию электронной почты
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на регистрацию электронной почты</param>
        /// <returns></returns>
        Task Delete(EmailRegistrationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на регистрацию электронной почты
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на регистрацию электронной почты</returns>
        Task<List<EmailRegistrationRequestLifeCycle>> GetLifeCycles();
    }
}
