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
                // Запись события в БД
                file.WriteLine($"{new string('-', 20)}\nПолучено новое сообщение\nТекст сообщения: {message}\nВремя: {DateTime.Now}\n{new string('-', 20)}");
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
                // Запись события в БД
                file.WriteLine($"Сообщение: {ex.Message}\tВремя: {DateTime.Now}");
            }
        }
    }
}
