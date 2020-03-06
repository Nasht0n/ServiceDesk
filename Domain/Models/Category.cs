using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Категория заявки"
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор категории заявки
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование категории заявки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор отрасли поддержки
        /// </summary>
        [Required]
        public int BranchId { get; set; }
        /// <summary>
        /// Объект отрасли поддержки
        /// </summary>
        public Branch Branch { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Category() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование категории заявки</param>
        /// <param name="branchId">Идентификатор отрасли поддержки</param>
        public Category(string name, int branchId)
        {
            // инициализация переменных
            Name = name;
            BranchId = branchId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   Id == category.Id &&
                   Name == category.Name &&
                   BranchId == category.BranchId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта категории заявки.</returns>
        public override string ToString()
        {
            return $"Category object:(Id:[{Id}];Name:[{Name}];BranchId:[{BranchId}]).";
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
