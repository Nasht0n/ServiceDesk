using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Учетные записи"
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Идентификатор учетной записи
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Password { get; set; }
        /// <summary>
        /// Дата регистрации учетной записи
        /// </summary>
        [Required]
        public DateTime DateRegistration { get; set; }
        /// <summary>
        /// Дата изменения пароля
        /// </summary>
        [Required]
        public DateTime DateChangePassword { get; set; }
        /// <summary>
        /// Время последнего входа в систему
        /// </summary>
        [Required]
        public DateTime LastEnterDateTime { get; set; }
        /// <summary>
        /// Признак активности учетной записи
        /// </summary>
        [Required]
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Признак изменения пароля при следующем входе в систему
        /// </summary>
        [Required]
        public bool ChangePasswordOnNextEnter { get; set; }
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [Required]
        public int EmployeeId { get; set; }
        /// <summary>
        /// Объект сотрудника
        /// </summary>
        public Employee Employee { get; set; }
        /// <summary>
        /// Список прав доступа
        /// </summary>
        public IList<Permission> Permissions { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Account() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="dateRegistration">Дата регистрации учетной записи</param>
        /// <param name="dateChangePassword">Дата изменения пароля</param>
        /// <param name="lastEnterDateTime">Время последнего входа в систему</param>
        /// <param name="isEnabled">Признак активности учетной записи</param>
        /// <param name="changePasswordOnNextEnter">Признак изменения пароля при следующем входе в систему</param>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        public Account(string username, string password, DateTime dateRegistration, DateTime dateChangePassword, DateTime lastEnterDateTime, bool isEnabled, bool changePasswordOnNextEnter, int employeeId)
        {
            Username = username;
            Password = password;
            DateRegistration = dateRegistration;
            DateChangePassword = dateChangePassword;
            LastEnterDateTime = lastEnterDateTime;
            IsEnabled = isEnabled;
            ChangePasswordOnNextEnter = changePasswordOnNextEnter;
            EmployeeId = employeeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Account account &&
                   Id == account.Id &&
                   Username == account.Username &&
                   Password == account.Password &&
                   DateRegistration == account.DateRegistration &&
                   DateChangePassword == account.DateChangePassword &&
                   LastEnterDateTime == account.LastEnterDateTime &&
                   IsEnabled == account.IsEnabled &&
                   ChangePasswordOnNextEnter == account.ChangePasswordOnNextEnter &&
                   EmployeeId == account.EmployeeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта учетной записи.</returns>
        public override string ToString()
        {
            return $"Account object:(Id:[{Id}];Username:[{Username}];Password:[{Password}];DateRegistration:[{DateRegistration.ToString()}];DateChangePassword:[{DateChangePassword.ToString()}];" +
                $"LastEnterDateTime:[{LastEnterDateTime}];IsEnabled:[{IsEnabled}];ChangePasswordOnNextEnter:[{ChangePasswordOnNextEnter}];EmployeeId:[{EmployeeId}]).";
        }
        /// <summary>
        /// Метод переопределния стандартного метода получения хэш-кода объекта
        /// </summary>
        /// <returns>Возвращает хэш-код объекта</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
