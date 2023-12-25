using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

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
            Functions func = new Functions();
            outlook.SendMessage<TerminalMessage>(new TerminalMessage($"Контроллер {GetType().Name} получил сообщение\nТекст сообщения: {message.Text}"));
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Количество Символов" , $"quantity"),
                        InlineKeyboardButton.WithCallbackData($" Сумма чисел" , $"sum")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                     await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Наш бот подсчитывает количество символов или подсчитывает сумму чисел.</b> {Environment.NewLine}"
                       , cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                case "/quantity":
                   
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Введите строку", cancellationToken: ct);
                    break;
                case "/sum":
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Введите числа через пробел", cancellationToken: ct);
                    break;
                default:
                    try
                    {
                        string str = func.SplitNumbers(message.Text);
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"{str}", cancellationToken: ct);
                    }
                    catch
                    {
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"В вашем сообщении: {message.Text.Length} символов", cancellationToken: ct);
                    }
                    break;
            }

        }
    }
}