using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.ConsoleApp.Models;

namespace TelegramBot.ConsoleApp.Services
{
    interface IStorage
    {
        Session GetSession(long chatId);
    }
}
