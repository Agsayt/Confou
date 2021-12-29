using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Interfaces
{
    internal interface ISellerManagement
    {
        /// <summary>
        /// Создание нового продавца
        /// </summary>
        /// <param name="seller">Сущность продавца</param>
        /// <param name="admin">Сущность администратора</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность создания продавца</returns>
        bool CreateSeller(Seller seller, Users admin, out string error);

        /// <summary>
        /// Обновление существующего продавца
        /// </summary>
        /// <param name="seller">Сущность продавца</param>
        /// <param name="admin">Сущность администратора</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность обновления продавца</returns>
        bool UpdateSeller(Seller seller, Users admin, out string error);

        /// <summary>
        /// Возврат одного билета
        /// </summary>
        /// <param name="seller">Сущность продавца</param>
        /// <param name="ticket">Сущность возвращаемого билета</param>
        /// <param name="user">Сущность того, кто производит возврат</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность возврата</returns>
        bool RefundTicket(Seller seller, Tickets ticket, Users user, out string error);

        /// <summary>
        /// Возвращения всех билетов события, проданных продавцом
        /// </summary>
        /// <param name="seller">Сущность продавца</param>
        /// <param name="events">Сущность события</param>
        /// <param name="user"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        bool RefundEvent(Seller seller, Events events, Users user, out string error);


        /// <summary>
        /// Продажа билета на событие продавцом
        /// </summary>
        /// <param name="seller">Сущность продавца</param>
        /// <param name="email">Почта покупателя</param>
        /// <param name="soldId">Идентификатор статуса продажи</param>
        /// <param name="author">Сущность того, кто выполнил действие</param>
        /// <param name="error">Выходная ошибка</param>
        /// <param name="user">Сущность пользователя, если зарегистрирован в системе</param>
        /// <returns>Успешность продажи</returns>
        bool SellTicket(Seller seller, Events events, int seat, string email, Users author, out string error, Users user = null, TicketPlacementType placement = null);

        /// <summary>
        /// Подтверждение оплаты покупателем
        /// </summary>
        /// <param name="email">Почта покупателя</param>
        /// <param name="author">Кто вносит запись</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность подтверждения</returns>
        bool PaymentConfirmation(string email, Users author, out string error);
    }
}
