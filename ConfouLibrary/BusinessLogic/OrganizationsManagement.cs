using ConfouLibrary.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    public class OrganizationsManagement : IOrganizationsManagement
    {
        public bool CreateOrganization(Organizations organization, ConfouLibrary.Users admin, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                context.Organizations.Add(organization);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Organizations", $"Admin '{admin.Login}' tries to create organization '{organization.OrganizationName}'", admin.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Safety.LogActions.NewLog(Action.CREATE, "Organizations", $"Admin '{admin.Login}' tries to create organization '{organization.OrganizationName}'", admin.UserId, DateTime.Now);
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            Safety.LogActions.NewLog(Action.CREATE, "Organizations", $"Admin '{admin.Login}' created organization '{organization.OrganizationName}'", admin.UserId, DateTime.Now);
            error = null;
            return true;
        }

        public List<Organizations> GetAllOrganizations(out string error, bool isEnabledOnly = false)
        {
            var orgList = new List<Organizations>();
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                if (isEnabledOnly)
                    orgList = context.Organizations.Where(x => x.Enabled == isEnabledOnly).ToList();
                else
                    orgList = context.Organizations.ToList();

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
            return orgList;
        }

        public bool UpdateOrganization(Organizations organization, ConfouLibrary.Users admin, out string error)
        {
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                var organizationToUpdate = context.Organizations.Where(x => x.OrganizationID == organization.OrganizationID).FirstOrDefault();
                organizationToUpdate = organization;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                error = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }

            error = null;
            return true;
        }
    }
}
