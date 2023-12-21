using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.ConsoleApp.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private Messanger outlook { get; set; } = new Messanger();
        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            outlook.SendMessage<TerminalMessage>(new TerminalMessage($"Контроллер {GetType().Name} получил сообщение\nТекст сообщения: {message.Text}"));
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено текстовое сообщение\nТекст собщения: {message.Text}", cancellationToken: ct);
        }
    }
}