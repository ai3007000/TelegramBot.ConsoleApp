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
        private readonly XmlSerializer serializer = new XmlSerializer(typeof(Person[]));
        private ILogger logger { get; set; }
        /// <summary>
        /// Сериализация объекта
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="Collection">Коллекция</param>
        void ISerializer.Serialize(string path, Person Collection)
        {
            logger.Event("Процесс сериализации коллекции запущен.");

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
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
        Person[]? ISerializer.DeSerialize(string path, Person Collection)
        {
            logger.Event("Процесс десериализации файла запущен.");
            Person[] newPeople;

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                newPeople = this.serializer.Deserialize(file) as Person[];
            }

            logger.Event("Процесс десериализации файла завершён.");
            return newPeople;
        }
    }
}
