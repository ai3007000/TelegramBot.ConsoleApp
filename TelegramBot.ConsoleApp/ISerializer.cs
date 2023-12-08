using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Интерфейс сериализации
    /// </summary>
    interface ISerializer
    {
        void Serialize(string path, Person Collection);
        Person[] DeSerialize(string path, Person Collection);
    }
}
