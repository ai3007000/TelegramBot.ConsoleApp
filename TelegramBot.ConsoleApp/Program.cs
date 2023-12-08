using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Xml.Serialization;
using Telegram.Bot.Types;

namespace TelegramBot.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person[]));

            Person human1 = new Person("Артём", "+76544964");
            Person human2 = new Person("Софья", "654684684");
            Person human3 = new Person("Liara", "561646845");
            Person[] people = new Person[3];
            people[0] = human1;
            people[1] = human2;
            people[2] = human3;
        }
    }
}