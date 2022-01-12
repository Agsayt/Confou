using ConfouLibrary.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    public class TicketManagement : ITicketManagement
    {
        public bool CreateTicket(Tickets ticket, Users author, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                context.Tickets.Add(ticket);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"User '{author.Login}' tries to create ticket '{ticket.TicketId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"User '{author.Login}' tries to create ticket '{ticket.TicketId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"User '{author.Login}' created ticket '{ticket.TicketId}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public bool CreateTicketType(TicketType ticketType, Events events, Users author, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                context.TicketType.Add(ticketType);
                context.TicketPool.Add(new TicketPool()
                {
                    Id = Guid.NewGuid(),
                    EventId = events.EventId,
                    TicketTypeId = ticketType.TicketTypeId
                });
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"User '{author.Login}' tries to create ticket type '{ticketType.TicketTypeId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"User '{author.Login}' tries to create ticket type '{ticketType.TicketTypeId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"User '{author.Login}' created ticket type '{ticketType.TicketTypeId}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public bool EditTicketType(TicketType ticketType, Users author, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                var ticketTypeToUpdate = context.TicketType.Where(x => x.TicketTypeId == ticketType.TicketTypeId).FirstOrDefault();
                if (ticketTypeToUpdate != null)
                    ticketTypeToUpdate = ticketType;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"User '{author.Login}' tries to update ticket type '{ticketType.TicketTypeId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"User '{author.Login}' tries to update ticket type '{ticketType.TicketTypeId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"User '{author.Login}' updated ticket type '{ticketType.TicketTypeId}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public List<Tickets> GetAllTicket(out string error)
        {
            var ticketList = new List<Tickets>();
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                ticketList = context.Tickets.ToList();

                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                error = ex.Message;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }


            error = null;
            return ticketList;
        }

        public List<Tickets> GetTickets<T>(T type, out string error)
        {
            var ticketList = new List<Tickets>();
            var context = new ConfouEntities();
            try
            {
                switch (typeof(T))
                {
                    case Type organization when organization == typeof(Organizations):
                        var orgEvents = context.Events.Where(x => x.OrgarnizatorID == (type as Organizations).OrganizationID).ToList();
                        foreach (var evnt in orgEvents)
                        {
                            ticketList.AddRange(evnt.Tickets);
                        }
                        break;

                    case Type seller when seller == typeof(Seller):
                        ticketList = context.Tickets.Where(x => x.SoldBy == (type as Seller).SellerId).ToList();
                        break;

                    case Type events when events == typeof(Events):
                        ticketList = context.Tickets.Where( x => x.EventId == (type as Events).EventId).ToList();
                        break;

                    case Type buyer when buyer == typeof(Buyer):
                        ticketList = context.Tickets.Where( x => x.BillingInformation.Buyer.BuyerEmail == (type as Buyer).BuyerEmail).ToList();
                        break;

                    
                    default:
                        error = "Недопустимый тип!";
                        break;

                }
            }
            catch (DbUpdateException e) //TODO: Использовать везде
            {
                error = e.Message;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                context.Dispose();
            }

            context.SaveChanges();
            error = null;
            return ticketList;
        }        

        public bool UpdateTicket(Tickets ticket, Users author, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                var ticketToUpdate = context.Tickets.Where(x => x.Equals(ticket)).FirstOrDefault();
                if (ticketToUpdate != null)
                    ticketToUpdate = ticket;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"User '{author.Login}' tries to update ticket '{ticket.TicketId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"User '{author.Login}' tries to update ticket '{ticket.TicketId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"User '{author.Login}' updates ticket '{ticket.TicketId}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }
    }
}
