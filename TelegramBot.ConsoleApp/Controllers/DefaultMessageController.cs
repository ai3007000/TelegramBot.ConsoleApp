using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.ConsoleApp.Controllers
{
    public class DefaultMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public DefaultMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение\nТекст сообщения: {message.Text}");
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено текстовое сообщение\nТекст собщения: {message.Text}", cancellationToken: ct);
        }
    }
}