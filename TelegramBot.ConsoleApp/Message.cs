using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    class Message
    {
        public string TextMessage {  get; set; }
        public Message(string TextMessage)
        {
            this.TextMessage = TextMessage;
        }
        public void PrintMessage()
        {
            Console.WriteLine($"{this.TextMessage}");

        }
    }
    class TerminalMessage : Message
    {
        public TerminalMessage(string TextMessage) : base(TextMessage) { }
    }

}
