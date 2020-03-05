using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Организация"
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Полное наименование организации
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Shortname { get; set; }
        /// <summary>
        /// Логотип организации
        /// </summary>
        public byte[] Logo { get; set; }
        /// <summary>
        /// Адрес организации
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        /// <summary>
        /// Телефон организации
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        /// <summary>
        /// Электронная почта организации
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Organization()
        {

        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="fullname">Полное наименование организации</param>
        /// <param name="shortname">Сокращенное наименование</param>
        /// <param name="address">Адрес организации</param>
        /// <param name="phone">Телефон организации</param>
        /// <param name="email">Электронная почта организации</param>
        public Organization(string fullname, string shortname, string address, string phone, string email)
        {
            Fullname = fullname;
            Shortname = shortname;
            Address = address;
            Phone = phone;
            Email = email;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Organization organization &&
                   Fullname == organization.Fullname &&
                   Shortname == organization.Shortname &&
                   Address == organization.Address &&
                   Phone == organization.Phone &&
                   Email == organization.Email;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта организации.</returns>
        public override string ToString()
        {
            return $"Organization object:(Fullname:[{Fullname}];Shortname:[{Shortname}];Address:[{Address}];Phone:[{Phone}];Email:[{Email}]).";
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
