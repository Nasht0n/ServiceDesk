namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность таблицы "Вид работы заявки"
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Идентификатор категории заявки
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование категории заявки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор категории заявки
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Категория заявки
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Service() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">Идентификатор вида работы заявки</param>
        /// <param name="name">Наименование вида работы</param>
        /// <param name="categoryId">Идентификатор категории заявки</param>
        public Service(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>        
        /// <param name="name">Наименование категории</param>
        /// <param name="categoryId">Идентификатор категории заявки</param>
        public Service(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
        /// <summary>
        /// Переопределенный метод строкового представления объекта категории заявки
        /// </summary>
        /// <returns>Возвращает строку, содержащую данные объекта категории заявки</returns>
        public override string ToString()
        {
            return $"Вид работы заявки: [Идентификатор вида работы заявки:{Id}; Идентификатор категории заявки: {CategoryId}; Наименование вида работы: {Name}].";
        }
        /// <summary>
        /// Переопределенный метод сравнения объектов категории заявки
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — если объекты одинаковые, иначе — false</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Service)
            {
                var temp = (Service)obj;
                if (Id == temp.Id && Name == temp.Name && CategoryId == temp.CategoryId) return true;
                else return false;
            }
            return false;
        }
        /// <summary>
        /// Переопределенный метод получения хэш кода объекта категории заявки
        /// </summary>
        /// <returns>Возвращает хэш код объекта категории заявки</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
