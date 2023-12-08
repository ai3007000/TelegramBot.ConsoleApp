using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Класс логгер
    /// </summary>
    class Logger : ILogger
    {
        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="message">Сообщение</param>
        void ILogger.Event(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Обработчик ошибки
        /// </summary>
        /// <param name="ex">Исключение</param>
        void ILogger.Error(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
