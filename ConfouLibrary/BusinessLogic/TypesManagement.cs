using ConfouLibrary.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    public class TypesManagement : ITypeManagement
    {
        public bool CreateNewEntry<T>(T entry, ConfouLibrary.Users admin, out string error, string entryName, int number = 0)
        {
            var context = new ConfouEntities();
            try
            {
                switch (typeof(T))
                {
                    case Type ageRestriction when ageRestriction == typeof(AgeRestrictionTypes):
                        context.AgeRestrictionTypes.Add(new AgeRestrictionTypes()
                        {
                            RestrictionName = entryName
                        });
                        break;

                    case Type deactivatedType when deactivatedType == typeof(DisactivatedTypes):
                        context.DisactivatedTypes.Add(new DisactivatedTypes()
                        {
                            TypeName = entryName
                        });
                        break;

                    case Type eventStatus when eventStatus == typeof(EventStatuses):
                        context.EventStatuses.Add(new EventStatuses()
                        {
                            StatusName = entryName
                        });
                        break;

                    case Type Roles when Roles == typeof(Roles):
                        context.Roles.Add(new Roles()
                        {
                           RoleName = entryName
                        });
                        break;

                    case Type ticketPlacementType when ticketPlacementType == typeof(TicketPlacementType):
                        var placement = new TicketPlacementType();
                        placement.PlacementName = entryName;
                        if (number != 0)
                            placement.PlacementNumber = number;
                        context.TicketPlacementType.Add(placement);
                        break;

                    case Type ticketStatuses when ticketStatuses == typeof(TicketStatuses):
                        context.TicketStatuses.Add(new TicketStatuses()
                        {
                            TicketStatusName = entryName
                        });
                        break;

                    case Type ticketTypeStatuses when ticketTypeStatuses == typeof(TicketTypeStatuses):
                        context.TicketTypeStatuses.Add(new TicketTypeStatuses()
                        {
                            TypeStatusName = entryName
                        });
                        break;

                    default:
                        error = "Недопустимый тип!";
                        return false;

                }
            }
            catch (DbUpdateException e) //TODO: Использовать везде
            {
                Safety.LogActions.NewLog(Action.CREATE, $"{typeof(T)}", $"Admin '{admin.Login}' tries to create enum '{entryName}'", admin.UserId, DateTime.Now);
                error = e.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, $"{typeof(T)}", $"Admin '{admin.Login}' tries to create enum '{entryName}'", admin.UserId, DateTime.Now);
                error = ex.Message;                
                return false;
            }
            finally
            {
                context.Dispose();
            }

            Safety.LogActions.NewLog(Action.CREATE, $"{typeof(T)}", $"Admin '{admin.Login}' created enum '{entryName}'", admin.UserId, DateTime.Now);
            context.SaveChanges();
            error = null;
            return true;
        }

        //TODO:Небезопасно - нужно ли оставлять?
        //public bool DeleteEntry<T>(T entry, out string error, Guid entriesTo)
        //{
            //var context = new ConfouEntities();
            //try
            //{
            //    switch (typeof(T))
            //    {
            //        case Type ageRestriction when ageRestriction == typeof(AgeRestrictionTypes):
                        

            //            context.SaveChanges();
            //            break;

            //        case Type deactivatedType when deactivatedType == typeof(DisactivatedTypes):
                        
            //            context.SaveChanges();
            //            break;

            //        case Type eventStatus when eventStatus == typeof(EventStatuses):
                        
            //            context.SaveChanges();
            //            break;

            //        case Type Roles when Roles == typeof(Roles):
                        
            //            break;

            //        case Type ticketPlacementType when ticketPlacementType == typeof(TicketPlacementType):
                        
            //            context.SaveChanges();
            //            break;

            //        case Type ticketStatuses when ticketStatuses == typeof(TicketStatuses):
                        
            //            context.SaveChanges();
            //            break;

            //        case Type ticketTypeStatuses when ticketTypeStatuses == typeof(TicketTypeStatuses):
                        
            //            break;

            //        default:
            //            error = "Недопустимый тип!";
            //            return false;

            //    }
            //}
            //catch (DbUpdateException e) //TODO: Использовать везде
            //{
            //    error = e.Message;
            //    return false;
            //}
            //catch (Exception ex)
            //{
            //    error = ex.Message;

            //    return false;
            //}
            //finally
            //{
            //    context.Dispose();
            //}

            //error = null;
            //return true;
        //}

        public bool UpdateEntry<T>(T entry, ConfouLibrary.Users admin, out string error, string entryName = null, int number = 0)
        {
            var context = new ConfouEntities();
            try
            {
                switch (typeof(T))
                {
                    case Type ageRestriction when ageRestriction == typeof(AgeRestrictionTypes):
                        var updatableAge = context.AgeRestrictionTypes.Where(x => x.AgeRestrictionId == (entry as AgeRestrictionTypes).AgeRestrictionId).FirstOrDefault();
                        updatableAge = (entry as AgeRestrictionTypes);
                        break;

                    case Type deactivatedType when deactivatedType == typeof(DisactivatedTypes):
                        var updatableDeact = context.DisactivatedTypes.Where(x => x.DisactivatedTypeId == (entry as DisactivatedTypes).DisactivatedTypeId).FirstOrDefault();
                        updatableDeact = (entry as DisactivatedTypes);
                        break;

                    case Type eventStatus when eventStatus == typeof(EventStatuses):
                        var updatableEventStatus = context.EventStatuses.Where(x => x.EventStatusId == (entry as EventStatuses).EventStatusId).FirstOrDefault();
                        updatableEventStatus = (entry as EventStatuses);
                        break;

                    case Type Roles when Roles == typeof(Roles):
                        var updatableRole = context.Roles.Where(x => x.RoleId == (entry as Roles).RoleId).FirstOrDefault();
                        updatableRole = (entry as Roles);
                        break;

                    case Type ticketPlacementType when ticketPlacementType == typeof(TicketPlacementType):
                        var updatablePlacement = context.TicketPlacementType.Where(x => x.Id == (entry as TicketPlacementType).Id).FirstOrDefault();
                        updatablePlacement = (entry as TicketPlacementType);
                        break;

                    case Type ticketStatuses when ticketStatuses == typeof(TicketStatuses):
                        var updatableTicketStatuses = context.TicketStatuses.Where(x => x.TicketStatusId == (entry as TicketStatuses).TicketStatusId).FirstOrDefault();
                        updatableTicketStatuses = (entry as TicketStatuses);
                        break;

                    case Type ticketTypeStatuses when ticketTypeStatuses == typeof(TicketTypeStatuses):
                        var updatableTicketTypeStatuses = context.TicketTypeStatuses.Where(x => x.TicketTypeStatusId == (entry as TicketTypeStatuses).TicketTypeStatusId).FirstOrDefault();
                        updatableTicketTypeStatuses = (entry as TicketTypeStatuses);
                        break;

                    default:
                        error = "Недопустимый тип!";
                        return false;

                }
            }
            catch (DbUpdateException e) //TODO: Использовать везде
            {
                Safety.LogActions.NewLog(Action.UPDATE, $"{typeof(T)}", $"Admin '{admin.Login}' tries to rename enum to '{entryName}'", admin.UserId, DateTime.Now);
                error = e.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.UPDATE, $"{typeof(T)}", $"Admin '{admin.Login}' tries to rename enum to '{entryName}'", admin.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                context.Dispose();
            }

            //TODO: адекватнее нужно придумать систему логирования, ибо хрень.
            Safety.LogActions.NewLog(Action.UPDATE, $"{typeof(T)}", $"Admin '{admin.Login}' renames enum to '{entryName}'", admin.UserId, DateTime.Now);
            context.SaveChanges();
            error = null;
            return true;
        }
    }
}
