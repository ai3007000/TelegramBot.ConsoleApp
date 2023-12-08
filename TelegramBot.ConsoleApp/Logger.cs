using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Класс логгер
    /// </summary>
    class Logger : ILogger
    {
        private DateTime time { get; set; } = DateTime.Now;
        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="message">Сообщение</param>
        void ILogger.Event(string message)
        {
            using (StreamWriter file = new StreamWriter("Events.txt", true))
            {
                file.WriteLine($"Сообщение: {message}\tВремя: {this.time}"); // Запись события в БД
            }
        }
        /// <summary>
        /// Обработчик ошибки
        /// </summary>
        /// <param name="ex">Исключение</param>
        void ILogger.Error(Exception ex)
        {
            using (StreamWriter file = new StreamWriter("Errors.txt", true))
            {
                file.WriteLine($"Сообщение: {ex.Message}\tВремя: {this.time}"); // Запись ошибки в БД
            }
        }
    }
}
