using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.ConsoleApp.Configuration;
using TelegramBot.ConsoleApp.Services;

namespace TelegramBot.ConsoleApp.Controllers
{
    class InlineKeyboardController
    {
        private Messanger outlook { get; set; } = new Messanger();
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        private AppSettings _appsetting { get; set; }

        public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;

            // Обновление пользовательской сессии новыми данными
            _memoryStorage.GetSession(callbackQuery.From.Id).LanguageCode = callbackQuery.Data;

            // Генерим информационное сообщение
            string languageText = callbackQuery.Data switch
            {
                "ru" => " Русский",
                "en" => " Английский",
                _ => String.Empty
            };

            outlook.SendMessage<TerminalMessage>(new TerminalMessage($"Контроллер {GetType().Name} обнаружил нажатие на кнопку {callbackQuery.Data}"));
            // Отправляем в ответ уведомление о выборе
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                $"<b>Язык аудио - {languageText}.{Environment.NewLine}</b>" +
                $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);
        }
    }
}