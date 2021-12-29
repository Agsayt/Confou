using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Interfaces
{
    internal interface IEventManagement
    {
        /// <summary>
        /// Создание нового события
        /// </summary>
        /// <param name="evnt">Сущность события</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность создания события</returns>
        bool CreateEvent(Events evnt, ConfouLibrary.Users author, out string error);

        /// <summary>
        /// Обновление существующего события
        /// </summary>
        /// <param name="evnt">Сущность события</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность создания события</returns>
        bool UpdateEvent(Events evnt, ConfouLibrary.Users author, out string error);

        /// <summary>
        /// Возврат ВСЕХ билетов события
        /// </summary>
        /// <param name="evnt">Сущность события</param>
        /// <param name="user">Сущность того, кто сделал возврат</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность возврата</returns>
        bool RefundAllTickets(Events evnt, int refundId, Users user, out string error);

        /// <summary>
        /// Получить список всех событий
        /// </summary>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Список событий</returns>
        List<Events> GetAllEvents(out string error);

        /// <summary>
        /// Получить список всех событий с определённым статусом
        /// </summary>
        /// <param name="statusId">Идентификатор статуса</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Список событий</returns>
        List<Events> GetEventsWithStatus(int statusId, out string error);

    }
}
