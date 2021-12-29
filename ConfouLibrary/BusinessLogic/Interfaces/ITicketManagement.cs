using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Interfaces
{
    internal interface ITicketManagement
    {
        /// <summary>
        /// Создание нового билета
        /// </summary>
        /// <param name="ticket">Сущность билета</param>
        /// <param name="author">Сущность того, кто создаёт билет</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность создания билета</returns>
        bool CreateTicket(Tickets ticket, Users author, out string error);

        /// <summary>
        /// Создание нового типа для билета
        /// </summary>
        /// <param name="ticketType">Сущность типа</param>
        /// <param name="events">Сущность события, к которому добавляется тип</param>
        /// <param name="author">Сущность того, кто создал тип</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность создания типа для билета</returns>
        bool CreateTicketType(TicketType ticketType, Events events, Users author, out string error);

        /// <summary>
        /// Редактирование типа для билета
        /// </summary>
        /// <param name="ticketType">Сущность типа</param>
        /// <param name="author">Сущность того, кто редактирует</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность редактирования типа</returns>
        bool EditTicketType(TicketType ticketType, Users author, out string error);

        //bool DeleteTicket(Tickets ticket, Users author, out string error);

        /// <summary>
        /// Обновление билета
        /// </summary>
        /// <param name="ticket">Сущность билета</param>
        /// <param name="author">Сущность того, кто обновляет</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность обновления билета</returns>
        bool UpdateTicket(Tickets ticket, Users author, out string error);
       
        /// <summary>
        /// Получение списка всех билетов
        /// </summary>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Список билетов</returns>
        List<Tickets> GetAllTicket(out string error);

        /// <summary>
        /// Получение списка билетов исходя из условия
        /// </summary>
        /// <typeparam name="T">Тип выборки билета</typeparam>
        /// <param name="type">Тип выборки билета</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Список билетов</returns>
        List<Tickets> GetTickets<T>(T type, out string error);



        //List<Tickets> GetTicketsByOrganization(Organizations organization);

        //List<Tickets> GetTicketsByEvent(Events evnt);

        //List<Tickets> GetTicketsBySeller(Seller seller);

        //List<Tickets> GetTicketsByBuyer(Buyer buyer);
    }
}
