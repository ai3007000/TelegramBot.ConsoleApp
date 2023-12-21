using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TelegramBot.ConsoleApp;
using TelegramBot.ConsoleApp.Controllers;
using TelegramBot.ConsoleApp.Services;
using TelegramBot.ConsoleApp.Configuration;

namespace VoiceTexterBot
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Messanger outlook = new Messanger();
            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            outlook.SendMessage<TerminalMessage>(new TerminalMessage("Сервис запущен."));
            // Запускаем сервис
            await host.RunAsync();
        }
        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IFileHandler, AudioFileHandler>();

            // Подключаем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            //services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            services.AddSingleton<IStorage, MemoryStorage>();

            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("6806016768:AAHEzpyB7JyRzphljkYmMbfoC0NDfwu5iOc"));
            services.AddHostedService<Bot>();
        }
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = @"E:\Програмирование\C#\TelegramBot.ConsoleApp\TelegramBot.ConsoleApp\DataBase",
                BotToken = "6806016768:AAHEzpyB7JyRzphljkYmMbfoC0NDfwu5iOc",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
                OutputAudioFormat = "wav"
            };
        }
    }
}
