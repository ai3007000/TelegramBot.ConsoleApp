using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Интерфейс воркера
    /// </summary>
    interface IWorker
    {
        /// <summary>
        /// Работа воркера
        /// </summary>
        void Work();
    }
}
