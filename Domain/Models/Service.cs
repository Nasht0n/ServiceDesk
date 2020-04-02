using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Виды работ"
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Идентификатор вида работы заявки
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование вида работы заявки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Видимость вида работы
        /// </summary>
        [Required]
        public bool Visible { get; set; }
        /// <summary>
        /// Требует ли, согласования данный вид работы
        /// </summary>
        [Required]
        public bool ApprovalRequired { get; set; }
        /// <summary>
        /// Требуется множественное согласование
        /// </summary>
        [Required]
        public bool ManyApprovalRequired { get; set; }
        /// <summary>
        /// Наименование контроллера веб приложения, выполняющего обработку текущего вида работы
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Controller { get; set; }
        /// <summary>
        /// Идентификатор категории работы, текущего вида работы
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
        /// <summary>
        /// Объект категории работы, текущего вида работы
        /// </summary>
        public virtual Category Category { get; set; }
        /// <summary>
        /// Список пользователей, согласовывающие текущий вид работы
        /// </summary>
        public virtual IList<ServicesApprover> Approvers { get; set; }
        /// <summary>
        /// Список групп исполнителей, закрепленных за данным видом работы
        /// </summary>
        public virtual IList<ServicesExecutorGroup> ExecutorGroups { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Service() {
            Approvers = new List<ServicesApprover>();
            ExecutorGroups = new List<ServicesExecutorGroup>();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование вида работы</param>
        /// <param name="approvalRequired">Признак, необходимого согласования текущей работы</param>
        /// <param name="controller">Наименование контроллера обработки текущей работы</param>
        /// <param name="categoryId">Категория работы</param>
        public Service(string name, bool approvalRequired, string controller, int categoryId)
        {
            Name = name;
            ApprovalRequired = approvalRequired;
            Controller = controller;
            CategoryId = categoryId;
            Approvers = new List<ServicesApprover>();
            ExecutorGroups = new List<ServicesExecutorGroup>();
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта вида работы.</returns>
        public override string ToString()
        {
            return $"Service object:(Id:[{Id}];Name:[{Name}];Controller:[{Controller}];CategoryId:[{CategoryId}];ApprovalRequired:[{ApprovalRequired}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if(obj is Service && obj != null)
            {
                Service temp = (Service)obj;
                if (temp.Id == Id && temp.ApprovalRequired == ApprovalRequired && temp.CategoryId == CategoryId && temp.Controller == Controller && temp.Name == Name) return true;
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
