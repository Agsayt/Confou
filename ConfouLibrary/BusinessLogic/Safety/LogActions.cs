using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Safety
{
    internal static class LogActions
    {


        /// <summary>
        /// Создание нового лога
        /// </summary>
        /// <param name="actionType">Тип действия</param>
        /// <param name="targetTable">Объект, над которым проводилось действие</param>
        /// <param name="description">Описание действия</param>
        /// <param name="author">Вызвавший действие</param>
        /// <param name="actionDate">Время действия</param>
        public static void NewLog(Action actionType, string targetTable, string description, Guid author, DateTime actionDate)
        {
            var context = new ConfouEntities();
            
                context.Logging.Add(new Logging()
                {
                    LogId = Guid.NewGuid(),
                    Action = actionType,
                    TargetTable = targetTable,
                    Description = description,
                    Author = author,
                    AuthorIP = GetIPAddress(),
                    ActionDate = DateTime.Now
                });

                context.SaveChanges();
                context.Dispose();
            
        }

        /// <summary>
        /// Получение IP адреса
        /// </summary>
        /// <returns>Строка с адресом IPv4</returns>
        private static string GetIPAddress()
        {
            string IPAddress = null;
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
    }
}
