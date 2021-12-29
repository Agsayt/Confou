using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Interfaces
{
    internal interface ITypeManagement
    {
        /// <summary>
        /// Создание нового перечислимого
        /// </summary>
        /// <typeparam name="T">Тип перечислимого</typeparam>
        /// <param name="entry">Тип перечислимого</param>
        /// <param name="error">Выходная ошибка</param>
        /// <param name="entryName">Название перечислимого</param>
        /// <param name="number">Значение перечислимого</param>
        /// <returns>Успешность создания записи</returns>
        bool CreateNewEntry<T>(T entry, ConfouLibrary.Users admin, out string error, string entryName = null, int number = 0);

        /// <summary>
        /// Обновление записи перечислимого
        /// </summary>
        /// <typeparam name="T">Тип перечислимого</typeparam>
        /// <param name="entry">Тип перечислимого</param>
        /// <param name="error">Выходная ошибка</param>
        /// <param name="entryName">Название перечислимого</param>
        /// <param name="number">Значение перечислимого</param>
        /// <returns>Успешность обновления записи</returns>
        bool UpdateEntry<T>(T entry, ConfouLibrary.Users admin, out string error, string entryName = null, int number = 0);

        /// <summary>
        /// Удаление перечислимого
        /// </summary>
        /// <typeparam name="T">Тип перечислимого</typeparam>
        /// <param name="entry">Сущность объекта удаления</param>
        /// <param name="error">Выходная ошибка</param>
        /// <param name="entriesTo">Замещение удаляемой записи на другу в сущностях, где присутствует</param>
        /// <returns></returns>
        //bool DeleteEntry<T>(T entry, out string error, Guid entriesTo);

    }
}
