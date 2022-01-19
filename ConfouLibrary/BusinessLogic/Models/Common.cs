using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Models
{
    public class TicketToBuy
    {
        public int TicketTypeId { get; set; }
        public string TicketName { get; set;}
        public double Price { get; set; }
        public string HallName { get; set; }
        public int Amount { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }

    public class BuyedTicket
    {
        TicketToBuy[] ticketToBuy { get; set; }

        public int EventId { get; set; }        
        public DateTime SoldTime { get; set; }
    }

    public class OrgEvent
    {
        public Guid EventId { get; set; }
        public DateTime EventsStartDate { get; set; }
        public DateTime EventsCreateDate { get; set; }
        public string EventName { get; set; }
        public string HallName { get; set; }
        public int TicketsOverall { get; set; }
        public int TicketsSold { get; set; }
        public int TicketsLeft { get; set; }
        public double Profit { get; set; }
    }

}
