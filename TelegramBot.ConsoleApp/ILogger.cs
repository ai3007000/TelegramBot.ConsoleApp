using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Интерфейс логгера
    /// </summary>
    interface ILogger
    {
        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="message">Сообщение</param>
        void Event(string message);
        /// <summary>
        /// Обработчик ошибки
        /// </summary>
        /// <param name="ex">Исключение</param>
        void Error(Exception ex);
    }
}
