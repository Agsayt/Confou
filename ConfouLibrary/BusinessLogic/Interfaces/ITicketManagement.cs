using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Interfaces
{
    internal interface ITicketManagement
    {
        
        bool CreateTicket(Tickets ticket, Users author, out string error);

        bool CreateTicketType(TicketType ticketType, Events events, Users author, out string error);

        bool EditTicketType(TicketType ticketType, Users author, out string error);

        //bool DeleteTicket(Tickets ticket, Users author, out string error);

        bool UpdateTicket(Tickets ticket, Users author, out string error);
       

        List<Tickets> GetAllTicket(out string error);

        List<Tickets> GetTickets<T>(T type, out string error);



        //List<Tickets> GetTicketsByOrganization(Organizations organization);

        //List<Tickets> GetTicketsByEvent(Events evnt);

        //List<Tickets> GetTicketsBySeller(Seller seller);

        //List<Tickets> GetTicketsByBuyer(Buyer buyer);
    }
}
