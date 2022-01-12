using ConfouLibrary.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    public class EventManagement : IEventManagement
    {

        public bool CreateEvent(Events evnt, ConfouLibrary.Users author, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                context.Events.Add(evnt);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Events", $"Admin '{author.Login}' tries to create event '{evnt.EventName}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Events", $"Admin '{author.Login}' tries to create event '{evnt.EventName}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.CREATE, "Events", $"Admin '{author.Login}' created event '{evnt.EventName}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }
        
        public bool UpdateEvent(Events evnt, ConfouLibrary.Users author, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                var eventToUpdate = context.Events.Where(e => e.EventId == evnt.EventId).FirstOrDefault();
                if (eventToUpdate != null)
                    eventToUpdate = evnt;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Events", $"Admin '{author.Login}' tries to update event '{evnt.EventId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Events", $"Admin '{author.Login}' tries to update event '{evnt.EventId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.UPDATE, "Events", $"Admin '{author.Login}' updated event '{evnt.EventId}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public List<Events> GetAllEvents(out string error)
        {
            List<Events> events = new List<Events>();
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                events = context.Events.ToList();
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
            return events;
        }

        public List<Events> GetEventsWithStatus(EventStatus status, out string error)
        {
            List<Events> events = new List<Events>();
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                events = context.Events.Where(x => x.EventStatus == status).ToList();
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
            return events;
        }

        public bool RefundAllTickets(Events evnt, Users author, out string error)
        {
            ConfouEntities context = null;
            List<Tickets> allEventTickets = new List<Tickets>();
            try
            {
                context = new ConfouEntities();

                allEventTickets = context.Tickets.ToList();
                if (allEventTickets.Count > 0)
                { 
                    foreach (var ticket in allEventTickets)
                    {
                        ticket.TicketStatus = TicketStatus.Refund;
                    }
                }
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Events", $"User '{author.Login}' tries to refund event '{evnt.EventId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Events", $"User '{author.Login}' tries to refund event '{evnt.EventId}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.UPDATE, "Events", $"User '{author.Login}' refunded event '{evnt.EventId}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }
    }
}
