namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность таблицы "Отрасль, определяющая специализацию заявки"
    /// </summary>
    public class Brunch
    {
        /// <summary>
        /// Идентификатор специализации заявки
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование специализации заявки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Brunch()
        {

        }
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="name">Наименование специализации заявки</param>
        public Brunch(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">Идентификатор специализации заявки</param>
        /// <param name="name">Наименование специализации</param>
        public Brunch(int id, string name)
        {
            Id = id;
            Name = name;
        }
        /// <summary>
        /// Переопределенный метод строкового представления объекта специализации заявки
        /// </summary>
        /// <returns>Возвращает строку, содержащую данные объекта специализации заявки</returns>
        public override string ToString()
        {
            return $"Специализация заявки: [Идентификатор:{Id}; Наименование специализации: {Name}].";
        }
        /// <summary>
        /// Переопределенный метод сравнения объектов специализации заявки
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — если объекты одинаковые, иначе — false</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Brunch)
            {
                var temp = (Brunch)obj;
                if (Id == temp.Id && Name == temp.Name) return true;
                else return false;
            }
            return false;
        }
        /// <summary>
        /// Переопределенный метод получения хэш кода объекта специализации заявки
        /// </summary>
        /// <returns>Возвращает хэш код объекта специализации заявки</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
