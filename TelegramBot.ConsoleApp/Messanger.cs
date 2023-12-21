using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    class Messanger
    {
        private ILogger logger { get; set; } = new Logger();
        public void SendMessage<T>(T message) where T : TerminalMessage
        {
            logger.Event(message.Text);
            message.PrintMessage();
        }
    }
}
