using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Сотрудники"
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>

        public int Id { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Surname { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; }
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Patronymic { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Post { get; set; }
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [MaxLength(150)]
        public string Email { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        [MaxLength(25)]
        public string Phone { get; set; }
        /// <summary>
        /// Является главой подразделения?
        /// </summary>
        [Required]
        public bool HeadOfUnit { get; set; }
        /// <summary>
        /// Идентификатор подразделения сотрудника
        /// </summary>
        [Required]
        public int SubdivisionId { get; set; }
        /// <summary>
        /// Объект подразделения сотрудника
        /// </summary>
        public Subdivision Subdivision { get; set; }

        public virtual IList<ServicesApprover> ApprovalServices { get; set; }
        public virtual IList<ExecutorGroupMember> ExecutorGroups { get; set; }
        public virtual IList<SubdivisionExecutor> ExecutorSubdivisions { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Employee() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="surname">Фамилия сотрудника</param>
        /// <param name="firstname">Имя сотрудника</param>
        /// <param name="patronymic">Отчество сотрудника</param>
        /// <param name="post">Должность сотрудника</param>
        /// <param name="phone">Телефон сотрудника</param>
        /// <param name="headOfUnit">Сотрудник является главой подразделения?</param>
        /// <param name="subdivisionId">Идентификатор подразделения</param>
        public Employee(string surname, string firstname, string patronymic, string post, string phone, bool headOfUnit, int subdivisionId)
        {
            Surname = surname;
            Firstname = firstname;
            Patronymic = patronymic;
            Post = post;
            Phone = phone;
            HeadOfUnit = headOfUnit;
            SubdivisionId = subdivisionId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   Id == employee.Id &&
                   Surname == employee.Surname &&
                   Firstname == employee.Firstname &&
                   Patronymic == employee.Patronymic &&
                   Post == employee.Post &&
                   Email == employee.Email &&
                   Phone == employee.Phone &&
                   HeadOfUnit == employee.HeadOfUnit &&
                   SubdivisionId == employee.SubdivisionId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта сотрудника.</returns>
        public override string ToString()
        {
            return $"Employee object:(Id:[{Id}];Surname:[{Surname}];Firstname:[{Firstname}];Patronymic:[{Patronymic}];Post:[{Post}];Email:[{Email}];Phone:[{Phone}];Email:[{Email}];HeadOfUnit:[{HeadOfUnit}];SubdivisionId:[{SubdivisionId}]).";
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