using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Класс сериализации объекта
    /// </summary>
    class Serializer : ISerializer
    {
        private XmlSerializer serializer { get; set; } = new XmlSerializer(typeof(Person[]));
        private ILogger logger { get; set; } = new Logger();
        private string pathDirectory { get; set; } = @"E:\Програмирование\C#\TelegramBot.ConsoleApp\TelegramBot.ConsoleApp\DataBase";
        private string path { get; set; }
        public Serializer(string path)
        {
            this.path = path;
        }
        /// <summary>
        /// Сериализация объекта
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="Collection">Коллекция</param>
        void ISerializer.Serialize(Person[] Collection)
        {
            logger.Event("Процесс сериализации коллекции запущен.");
            if (!Directory.Exists(this.pathDirectory))
            {
                Directory.CreateDirectory(this.pathDirectory);
            }
        
            using (FileStream file = new FileStream(Path.Combine(this.pathDirectory, this.path), FileMode.OpenOrCreate))
            {
                this.serializer.Serialize(file, Collection);
            }

            logger.Event("Процесс сериализации коллекции завершён.");
        }
        /// <summary>
        /// Десиарелизация объекта
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="Collection">Коллекция</param>
        /// <returns></returns>
        Person[]? ISerializer.DeSerialize()
        {
            logger.Event("Процесс десериализации файла запущен.");
            Person[]? newPeople;

            using (FileStream file = new FileStream(Path.Combine(this.pathDirectory, this.path), FileMode.OpenOrCreate))
            {
                newPeople = this.serializer.Deserialize(file) as Person[];
            }

            logger.Event("Процесс десериализации файла завершён.");
            return newPeople;
        }
    }
}
