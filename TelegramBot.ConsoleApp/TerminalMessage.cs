using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.ConsoleApp
{
    class TerminalMessage
    {
        public string Text { get; set; }
        public TerminalMessage(string Text)
        {
            this.Text = Text;
        }
        public void PrintMessage()
        {
            Console.WriteLine(this.Text);
        }
    }
}
