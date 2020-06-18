using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events
{
    /// <summary>
    /// Интерфейс доступа к хранилищу данных о проводимых мероприятиях
    /// </summary>
    public interface ITechnicalSupportEventInfoRepository
    {
        /// <summary>
        /// Метод добавления записи о проводимых мероприятиях
        /// </summary>
        /// <param name="request">Запись о проводимых мероприятиях</param>
        /// <returns>Возвращает объект о проводимых мероприятиях</returns>
        Task<TechnicalSupportEventInfos> Add(TechnicalSupportEventInfos equipments);
        /// <summary>
        /// Метод редактировния записи о проводимых мероприятиях
        /// </summary>
        /// <param name="request">Запись о проводимых мероприятиях</param>
        /// <returns>Возвращает объект о проводимых мероприятиях</returns>
        Task<TechnicalSupportEventInfos> Update(TechnicalSupportEventInfos equipments);
        /// <summary>
        /// Метод удаления записи о проводимых мероприятиях
        /// </summary>
        /// <param name="request">Запись о проводимых мероприятиях</param>
        /// <returns></returns>
        Task Delete(TechnicalSupportEventInfos equipments);
        /// <summary>
        /// Метод получения списка записей о проводимых мероприятиях
        /// </summary>
        /// <returns>Возвращает список записей о проводимых мероприятиях</returns>
        Task<List<TechnicalSupportEventInfos>> GetEquipments();
    }
}
