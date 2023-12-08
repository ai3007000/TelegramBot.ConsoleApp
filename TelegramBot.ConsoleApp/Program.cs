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
            try
            {
                IWorker worker = new Worker();
                worker.Work();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}