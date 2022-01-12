using ConfouLibrary.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    public class SellerManagement : ISellerManagement
    {
        public bool CreateSeller(Seller seller, Users admin, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                context.Seller.Add(seller);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Events", $"Admin '{admin.Login}' tries to create seller '{seller.SellerName}'", admin.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Events", $"Admin '{admin.Login}' tries to create seller '{seller.SellerName}'", admin.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.CREATE, "Events", $"Admin '{admin.Login}' created seller '{seller.SellerName}'", admin.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public bool PaymentConfirmation(string email, Users author, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                var billingToConfirm = context.BillingInformation.Where(x => x.BuyerEmail == email).FirstOrDefault();
                if (billingToConfirm != null)
                {
                    billingToConfirm.TransactionResult = true;
                    var ticketToConfirm = context.Tickets.Where(x => x.BillingId == billingToConfirm.BillingId).FirstOrDefault();
                    if (ticketToConfirm != null)
                    {
                        ticketToConfirm.TicketStatus = TicketStatus.Sold;
                    }
                }
                                
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "BillingInformation", $"Buyer '{email}' doesn't confirmed his payment", author.UserId, DateTime.Now);
                Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"Ticket doesn't solded to buyer '{email}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "BillingInformation", $"Buyer '{email}' doesn't confirmed his payment", author.UserId, DateTime.Now);
                Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"Ticket doesn't solded to buyer '{email}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }
            Safety.LogActions.NewLog(Action.UPDATE, "BillingInformation", $"Buyer '{email}' confirmed his payment", author.UserId, DateTime.Now);
            Safety.LogActions.NewLog(Action.UPDATE, "Tickets", $"Ticket solded to buyer '{email}'", author.UserId, DateTime.Now);
            Safety.LogActions.NewLog(Action.SELL, "Tickets", $"Seller '{author.Login}' sold ticket for buyer '{email}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public bool RefundEvent(Seller seller, Events events, Users user, out string error)
        {
            ConfouEntities context = null;
            List<Tickets> ticketList = new List<Tickets>();
            try
            {
                context = new ConfouEntities();
                ticketList = context.Tickets.Where(t => t.SoldBy == seller.SellerId && t.EventId == events.EventId).ToList();
                if (ticketList.Count > 0)
                {
                    foreach (var ticket in ticketList)
                    {
                        ticket.TicketStatus = TicketStatus.Refund;
                    }                    
                }                

                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.REFUND, "Tickets", $"User '{user.Login}' tries to refund seller tickets for event '{seller.SellerName}'", user.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.REFUND, "Tickets", $"User '{user.Login}' tries to refund seller tickets for event'{seller.SellerName}'", user.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.REFUND, "Events", $"User '{user.Login}' refunded seller tickets from event '{seller.SellerName}'", user.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public bool RefundTicket(Seller seller, Tickets ticket, Users user, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                var ticketToRefund = context.Tickets.Where(x => x == ticket).FirstOrDefault();
                if (ticketToRefund != null)
                    ticketToRefund.TicketStatus = TicketStatus.Refund;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.REFUND, "Tickets", $"User '{user.Login}' tries to refund seller tickets for event '{seller.SellerName}'", user.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.REFUND, "Tickets", $"User '{user.Login}' tries to refund seller tickets for event '{seller.SellerName}'", user.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.REFUND, "Tickets", $"User '{user.Login}' tries to refund seller tickets for event '{seller.SellerName}'", user.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public bool SellTicket(Seller seller, Events events, int seat, string email, Users author, out string error, Users user = null, TicketPlacementType placement = null)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();

                var newBuyer = new Buyer();
                newBuyer.BuyerEmail = email;
                if (user != null)
                    newBuyer.UserId = user.UserId;
                newBuyer.CreateDate = DateTime.Now;

                var newTicket = new Tickets();
                newTicket.TicketId = Guid.NewGuid();
                newTicket.EventId = events.EventId;
                newTicket.Seat = seat;
                if (placement != null)
                    newTicket.Placement = placement.Id;
                newTicket.TicketCode = Guid.NewGuid();
                newTicket.TicketStatus = TicketStatus.OnHold;
                newTicket.SoldDate = DateTime.Now;
                newTicket.SoldBy = seller.SellerId;

                var newBilling = new BillingInformation();
                newBilling.BillingId = Guid.NewGuid();
                newBilling.TicketId = newTicket.TicketId;
                newBilling.TransactionResult = false; // Not payed
                newBilling.SellerId = seller.SellerId;
                newBilling.BuyerEmail = email;

                newTicket.BillingId = newBilling.BillingId;

                context.Buyer.Add(newBuyer);
                context.BillingInformation.Add(newBilling);

                TicketManagement tm = new TicketManagement();
                bool result = tm.CreateTicket(newTicket, author, out string errorMessage);
                if (!result)
                {
                    Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"User '{author.Login}' tries to create a ticket for '{email}'", author.UserId, DateTime.Now);
                    error = errorMessage;
                    return false;
                }

                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "BillingInformation", $"User '{author.Login}' tries to create a billing for '{email}'", author.UserId, DateTime.Now);
                Safety.LogActions.NewLog(Action.CREATE, "Buyer", $"User '{author.Login}' tries to create a buyer for '{email}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "BillingInformation", $"User '{author.Login}' tries to create a billing for '{email}'", author.UserId, DateTime.Now);
                Safety.LogActions.NewLog(Action.CREATE, "Buyer", $"User '{author.Login}' tries to create a buyer for '{email}'", author.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.CREATE, "Buyer", $"Seller '{author.Login}' created buyer '{email}'", author.UserId, DateTime.Now);
            Safety.LogActions.NewLog(Action.CREATE, "BillingInformation", $"Seller '{author.Login}' created billingInformation for buyer'{email}'", author.UserId, DateTime.Now);
            Safety.LogActions.NewLog(Action.CREATE, "Tickets", $"Seller '{author.Login}' created ticket for buyer '{email}'", author.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public bool UpdateSeller(Seller seller, Users admin, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                var sellerToUpdate = context.Seller.Where(e => e.SellerId == seller.SellerId).FirstOrDefault();
                if (sellerToUpdate != null)
                    sellerToUpdate = seller;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Events", $"Admin '{admin.Login}' tries to update seller '{seller.SellerId}'", admin.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, "Events", $"Admin '{admin.Login}' tries to update seller '{seller.SellerId}'", admin.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.UPDATE, "Events", $"Admin '{admin.Login}' updated seller '{seller.SellerId}'", admin.UserId, DateTime.Now);
            error = null;
            return true;
        }
    }
}
