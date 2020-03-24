using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Разрешения доступа"
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Идентификатор разрешения доступа
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Заголовок разрешения доступа
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        /// <summary>
        /// Имя разрешения доступа
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        /// <summary>
        /// Список учетных записей с данным разрешением доступа
        /// </summary>
        public IList<AccountPermission> Accounts { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Permission()
        {
            Accounts = new List<AccountPermission>();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="title">Заголовок разрешения доступа</param>
        /// <param name="description">Описание разрешения доступа</param>
        public Permission(string title, string description)
        {
            // инициализация переменных
            Title = title;
            Description = description;
            Accounts = new List<AccountPermission>();
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта разрешения доступа.</returns>
        public override string ToString()
        {
            return $"Permission object:(Id:[{Id}];Title:[{Title}];Description:[{Description}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Permission permission &&
                   Id == permission.Id &&
                   Title == permission.Title && Description == permission.Description;
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