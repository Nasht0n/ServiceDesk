namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность таблицы "Категория заявки"
    /// </summary>
    public class Category
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
        /// Идентификатор специализации заявки
        /// </summary>
        public int BrunchId { get; set; }
        /// <summary>
        /// Специализация заявки
        /// </summary>
        public Brunch Brunch { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Category() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">Идентификатор категории заявки</param>
        /// <param name="name">Наименование категории</param>
        /// <param name="specializationId">Идентификатор специализации заявки</param>
        public Category(int id, string name, int specializationId)
        {
            Id = id;
            Name = name;
            BrunchId = specializationId;
        }
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="name">Наименование категории заявки</param>
        /// <param name="specializationId">Идентификатор специализации заявки</param>
        public Category(string name, int specializationId)
        {
            Name = name;
            BrunchId = specializationId;
        }
        /// <summary>
        /// Переопределенный метод строкового представления объекта категории заявки
        /// </summary>
        /// <returns>Возвращает строку, содержащую данные объекта категории заявки</returns>
        public override string ToString()
        {
            return $"Категория заявки: [Идентификатор категории заявки:{Id}; Идентификатор специализации заявки: {BrunchId}; Наименование категории: {Name}].";
        }
        /// <summary>
        /// Переопределенный метод сравнения объектов категории заявки
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — если объекты одинаковые, иначе — false</returns>
        public override bool Equals(object obj)
        {
            if(obj != null && obj is Category)
            {
                var temp = (Category)obj;
                if (Id == temp.Id && Name == temp.Name && BrunchId == temp.BrunchId) return true;
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
