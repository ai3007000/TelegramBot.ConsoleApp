using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    /// <summary>
    /// Класс персона
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string NumberOfPhone { get; set; }
        public Person() { }
        public Person(string Name, string NumberOfPhone)
        {
            this.Name = Name;
            this.NumberOfPhone = NumberOfPhone;
        }
    }
}
