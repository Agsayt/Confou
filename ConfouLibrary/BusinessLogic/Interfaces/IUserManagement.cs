using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    internal interface IUserManagement
    {
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="user">Сущность пользователя</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность добавления</returns>
        bool CreateUser(ConfouLibrary.Users user, out string error);

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="user">Сущность пользователя</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность обновления</returns>
        bool UpdateUser(ConfouLibrary.Users user, out string error);

        /// <summary>
        /// Отключение учётной записи пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="banTill">Срок отключения учётной записи</param>
        /// <param name="adminId">Идентификатор блокирующего запись</param>
        /// <param name="deactivationType">Тип деактивации записи</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность блокировки записи</returns>
        bool DisableUser(Guid userId, DateTime banTill, Guid adminId, int deactivationType, out string error, string reason = null);

        /// <summary>
        /// Изменение роли пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность имзенения роли</returns>
        bool ChangeRole(Guid userId, Guid roleId, Guid adminId, out string error);

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="login">Введённый пользователем логин</param>
        /// <param name="password">Введённый пользователем пароль</param>
        /// <param name="userId">В случае удачи возвращает id пользователя</param>
        /// <returns>Успешность авторизации</returns>
        bool VerifyUser(string login, string password, out Guid userId, out string error);

        /// <summary>
        /// Получение списка пользователей (полного или определённое количество
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="usersAmount">Количество пользователей на страницу</param>
        /// <returns>Список пользователей</returns>
        List<ConfouLibrary.Users> GetUsers(out string error, bool isEnabledOnly = false);



    }
}
