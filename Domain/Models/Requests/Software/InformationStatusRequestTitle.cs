using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Requests.Software
{
    /// <summary>
    /// Класс-сущность, содержащий заголовки страниц сайта"
    /// </summary>
    public class InformationStatusRequestTitle
    {
        /// <summary>
        /// Идентификтатор заголовка
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор заявки о состоянии информации, размещенной на сайте университета
        /// </summary>
        [Required]
        public int RequestId { get; set; }
        /// <summary>
        /// Заголовок страницы сайта
        /// </summary>
        [Required]
        public string Title { get; set; }
        [ForeignKey("RequestId")]
        public InformationStatusRequest Request { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InformationStatusRequestTitle() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="requestId">Идентификатор заявки</param>
        /// <param name="title">Заголовок страницы сайта</param>
        public InformationStatusRequestTitle(int requestId, string title)
        {
            RequestId = requestId;
            Title = title;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта жизненного цикла заявки на разработку программного обеспечения.</returns>
        public override string ToString()
        {
            return $"InformationStatusRequestTitle object:(Id:[{Id}];RequestId:[{RequestId}];Title:[{Title}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is InformationStatusRequestTitle && obj != null)
            {
                InformationStatusRequestTitle temp = (InformationStatusRequestTitle)obj;
                if (temp.Id == Id && temp.RequestId == RequestId && temp.Title == Title) return true;
                else return false;
            }
            return false;
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
