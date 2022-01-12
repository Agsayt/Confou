using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    public class UsersManagement : IUserManagement
    {
        public bool ChangeRole(Guid userId, UserRole role, Guid adminId, out string error)
        {
            try
            {
                var context = new ConfouEntities();
                var user = context.Users.Where(x => x.UserId == userId).FirstOrDefault();
                if (user != null)
                {
                    user.RoleId = role; 
                    context.SaveChanges();
                    Safety.LogActions.NewLog(Action.UPDATE, "Users", $"Admin changes role of user '{user.Login}'", adminId, DateTime.Now);
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                error = ex.InnerException.InnerException.Message;
                Safety.LogActions.NewLog(Action.UPDATE, "Users", $"Admin tries to change role of user with Guid '{userId}'", adminId, DateTime.Now);
                return false;
            }

            error = null;
            return true;
        }

        public bool CreateUser(Users user, out string error)
        {
            try
            {

                var context = new ConfouEntities();
                
                    user.PasswordHash = BusinessLogic.Safety.Encryption.EncryptPassword(user.PasswordHash, user.Login);
                    context.Users.Add(user);
                    Safety.LogActions.NewLog(Action.CREATE, "Users", $"Admin creates user with login {user.Login}'", user.CreateAuthor, DateTime.Now);
                    context.SaveChanges();
                    context.Dispose();
                
                
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Safety.LogActions.NewLog(Action.CREATE, "Users", $"Admin tries to creates user with login {user.Login}'", user.CreateAuthor, DateTime.Now);
                return false;
            }

            error = null;
            return true;
        }

        public bool DisableUser(Guid userId, DateTime banTill, Guid adminId, int deactivationType, out string error, string reason = null)
        {
            var context = new ConfouEntities();
            try
            {
                var disAccount = new DisactivatedAccounts()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Reason = reason,
                    Date = DateTime.Now,
                    DisactivatedBy = adminId,
                    DisactivatedTime = banTill,
                    DisactivatedType = deactivationType,
                };

                context.DisactivatedAccounts.Add(disAccount);
                context.SaveChanges();
                Safety.LogActions.NewLog(Action.DISABLE, "Users", $"Admin disable user with id '{userId}' ", adminId, DateTime.Now);
                context.Dispose();
            }
            catch (Exception ex)
            {
                error = ex.InnerException.InnerException.Message;
                Safety.LogActions.NewLog(Action.DISABLE, "Users", $"Admin tries to disable user with id '{userId}' ", adminId, DateTime.Now);
                return false;
            }
            finally
            {
                context.Dispose();
            }

            error = null;
            return true;
        }

        public Users GetUserByID(Guid id, out string error)
        {
            Users user = null;
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                
                user = context.Users.Where(x => x.UserId == id).FirstOrDefault();                

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
            return user;
        }

        //TODO: Неоптимально, т.к. если будет более тысячи записей, то программа "зависнет" или долго будет обрабатывать запрос
        public List<Users> GetUsers(out string error, bool isEnabledOnly = false)
        {
            var userList = new List<ConfouLibrary.Users>();
            ConfouEntities context = null;
            try
            {
                context = new ConfouEntities();
                if (isEnabledOnly)
                    userList = context.Users.Where(x => x.Enabled == isEnabledOnly).ToList();
                else
                    userList = context.Users.ToList();

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
            return userList;

        }

        public bool UpdateUser(Users user, out string error)
        {
            var context = new ConfouEntities();

            try
            {

                var originalUser = context.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
                if (originalUser != null)
                {
                    originalUser = user;
                    context.SaveChanges();
                    Safety.LogActions.NewLog(Action.UPDATE, "Users", $"Admin update user with login '{user.Login}' ", user.CreateAuthor, DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Safety.LogActions.NewLog(Action.UPDATE, "Users", $"Admin tries to update user with login '{user.Login}' ", user.CreateAuthor, DateTime.Now);
                return false;
            }
            finally
            {
                context.Dispose();
            }

            error = null;
            return true;
        }

        //TODO: подумать, надо ли логировать неудачные попытки входа
        public bool VerifyUser(string login, string password, out Guid userId, out string error)
        {
            Guid requestedId = Guid.Empty;
            bool IsVerified = false;
            var context = new ConfouEntities();

            try
            {
                var searchedUser =context.Users.Where(x => x.Login == login).FirstOrDefault();

                if (searchedUser != null)
                {
                    IsVerified = Safety.Encryption.VerifyPassword(password, login, searchedUser.PasswordHash);

                    if (IsVerified)
                    {
                        requestedId = searchedUser.UserId;
                        userId = requestedId;
                        error = null;
                        return true;
                    }
                }

                error = "Не верный логин или пароль, или учётная запись не существует";
                userId = requestedId;
                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                userId = requestedId;
                return false;
            }
            finally
            {
                context.Dispose();
            }
        }

    }
}
