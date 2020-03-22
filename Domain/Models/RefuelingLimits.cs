using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Лимиты на заправку"
    /// </summary>
    public class RefuelingLimits
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Год установки лимита
        /// </summary>
        [Required]
        public int Year { get; set; }
        /// <summary>
        /// Количество заправок
        /// </summary>
        [Required]
        public int Count { get; set; }
        /// <summary>
        /// Идентификатор подразделения, на которое установлен лимит заправок
        /// </summary>
        [Required]
        public int SubdivisionId { get; set; }
        /// <summary>
        /// Объект подразделения, на которое установлен лимит заправок
        /// </summary>
        public Subdivision Subdivision { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RefuelingLimits()
        {

        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="year">Год установки лимита</param>
        /// <param name="count">Количество заправок</param>
        /// <param name="subdvisionId">Идентификатор подразделения, на которое установлен лимит заправок</param>
        public RefuelingLimits(int year, int count, int subdvisionId)
        {
            Year = year;
            Count = count;
            SubdivisionId = subdvisionId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта лимитов заправок.</returns>
        public override string ToString()
        {
            return $"RefuelingLimits object:(Id:[{Id}];Year:[{Year}];Count:[{Count}];SubdivisionId:[{SubdivisionId}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is RefuelingLimits limits &&
                   Id == limits.Id &&
                   Year == limits.Year &&
                   Count == limits.Count &&
                   SubdivisionId == limits.SubdivisionId &&
                   EqualityComparer<Subdivision>.Default.Equals(Subdivision, limits.Subdivision);
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
