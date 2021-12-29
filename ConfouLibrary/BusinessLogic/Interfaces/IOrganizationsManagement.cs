using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Interfaces
{
    internal interface IOrganizationsManagement
    {
        /// <summary>
        /// Создание новой организации
        /// </summary>
        /// <param name="organization">Сущность организации</param>
        /// <param name="admin">Сущность того, кто добавляет запись</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность создания организации</returns>
        bool CreateOrganization(Organizations organization, ConfouLibrary.Users admin, out string error);

        /// <summary>
        /// Обновление существующей организации
        /// </summary>
        /// <param name="organization">Сущность организации</param>
        /// <param name="admin">Сущность того, кто обновляет запись</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Успешность обновления организации</returns>
        bool UpdateOrganization(Organizations organization, ConfouLibrary.Users admin, out string error);

        /// <summary>
        /// Получение списка организаций
        /// </summary>
        /// <param name="error">Выходная ошибка</param>
        /// <param name="isEnabledOnly">Активные или нет</param>
        /// <returns>Список организаций</returns>
        List<Organizations> GetAllOrganizations(out string error, bool isEnabledOnly = false);        


    }
}
