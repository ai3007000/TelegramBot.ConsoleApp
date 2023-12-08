using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Класс воркера
    /// </summary>
    class Worker : IWorker
    {
        private ILogger logger { get; set; } = new Logger();
        /// <summary>
        /// Работа воркера
        /// </summary>
        void IWorker.Work()
        {
            try
            {
                Person[] people = new Person[3];
                people[0] = new Person("Артём", "+76544964");
                people[1] = new Person("Софья", "654684684");
                people[2] = new Person("Liara", "561646845");

                ISerializer serializer = new Serializer("Collections.xml");
                serializer.Serialize(people);
                Person[] newPeople = serializer.DeSerialize();
                foreach (var item in newPeople)
                {
                    Console.WriteLine(item.ToString());
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
