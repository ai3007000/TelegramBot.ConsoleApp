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
        private readonly string path = @"E:\Програмирование\C#\TelegramBot.ConsoleApp\TelegramBot.ConsoleApp\DataBase";
        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="message">Сообщение</param>
        void ILogger.Event(string message)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (StreamWriter file = new StreamWriter(Path.Combine(this.path, "Events.txt"), true))
            {
                file.WriteLine($"Сообщение: {message}\tВремя: {DateTime.Now}"); // Запись события в БД
            }

        }
        /// <summary>
        /// Обработчик ошибки
        /// </summary>
        /// <param name="ex">Исключение</param>
        void ILogger.Error(Exception ex)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (StreamWriter file = new StreamWriter(Path.Combine(this.path, "Errors.txt"), true))
            {
                file.WriteLine($"Сообщение: {ex.Message}\tВремя: {DateTime.Now}"); // Запись события в БД
            }
        }
    }
}
