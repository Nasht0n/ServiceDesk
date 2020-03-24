using Domain.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Прикрепленные файлы"
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Идентификатор файла
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование файла
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Filename { get; set; }
        /// <summary>
        /// Дата загрузки файла
        /// </summary>
        [Required]
        public DateTime DateUploaded { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Path { get; set; }
        /// <summary>
        /// Навигационное свойство к заявкам на разработку программного обеспечения
        /// </summary>
        public virtual IList<SoftwareDevelopmentRequestAttachment> SoftwareDevelopmentRequests { get; set; }
        /// <summary>
        /// Навигационное свойство к заявкам на доработку программного обеспечения
        /// </summary>
        public virtual IList<SoftwareReworkRequestAttachment> SoftwareReworkRequests { get; set; }
        /// <summary>
        /// Навигационное свойство к заявкам на аннулирование учетных записей
        /// </summary>
        public virtual IList<AccountCancellationRequestAttachment> AccountCancellationRequests { get; set; }
        /// <summary>
        /// Навигационное свойство к заявкам на отключение учетных записей
        /// </summary>
        public virtual IList<AccountDisconnectRequestAttachment> AccountDisconnectRequests { get; set; }
        /// <summary>
        /// Навигационное свойство к заявкам на утрату учетных записей
        /// </summary>
        public virtual IList<AccountLossRequestAttachment> AccountLossRequests { get; set; }
        /// <summary>
        /// Навигационное свойство к заявкам на регистрацию учетных записей
        /// </summary>
        public virtual IList<AccountRegistrationRequestAttachment> AccountRegistrationRequests { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Attachment() 
        {
            SoftwareDevelopmentRequests = new List<SoftwareDevelopmentRequestAttachment>();
            SoftwareReworkRequests = new List<SoftwareReworkRequestAttachment>();
            AccountCancellationRequests = new List<AccountCancellationRequestAttachment>();
            AccountDisconnectRequests = new List<AccountDisconnectRequestAttachment>();
            AccountLossRequests = new List<AccountLossRequestAttachment>();
            AccountRegistrationRequests = new List<AccountRegistrationRequestAttachment>();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="filename">Наименование файла</param>
        /// <param name="dateUploaded">Дата загрузки файла</param>
        /// <param name="path">Путь к файлу</param>
        public Attachment(string filename, DateTime dateUploaded, string path)
        {
            Filename = filename;
            DateUploaded = dateUploaded;
            Path = path;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Attachment attachment &&
                   Id == attachment.Id &&
                   Filename == attachment.Filename &&
                   DateUploaded == attachment.DateUploaded &&
                   Path == attachment.Path;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта прикрепленного файла.</returns>
        public override string ToString()
        {
            return $"Attachment object:(Id:[{Id}];Filename:[{Filename}];DateUploaded:[{DateUploaded}];Path:[{Path}]).";
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
