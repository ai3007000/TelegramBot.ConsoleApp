using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ConsoleApp.Configuration;
using TelegramBot.ConsoleApp.Utilities;

namespace TelegramBot.ConsoleApp.Services
{
    class AudioFileHandler : IFileHandler
    {
        private readonly AppSettings _appSettings;
        private readonly ITelegramBotClient _telegramBotClient;
        private Messanger outlook { get; set; } = new Messanger();
        public AudioFileHandler(ITelegramBotClient telegramBotClient, AppSettings appSettings)
        {
            _appSettings = appSettings;
            _telegramBotClient = telegramBotClient;
        }

        public async Task Download(string fileId, CancellationToken ct)
        {
            // Генерируем полный путь файла из конфигурации
            string inputAudioFilePath = Path.Combine(_appSettings.DownloadsFolder, $"{_appSettings.AudioFileName}.{_appSettings.InputAudioFormat}");

            using (FileStream destinationStream = new FileStream(inputAudioFilePath, FileMode.Create))
            {
                // Загружаем информацию о файле
                var file = await _telegramBotClient.GetFileAsync(fileId, ct);
                if (file.FilePath == null)
                    return;

                // Скачиваем файл
                await _telegramBotClient.DownloadFileAsync(file.FilePath, destinationStream, ct);
            }
        }

        public string Process(string languageCode)
        {
            string inputAudioPath = Path.Combine(_appSettings.DownloadsFolder, $"{_appSettings.AudioFileName}.{_appSettings.InputAudioFormat}");
            string outputAudioPath = Path.Combine(_appSettings.DownloadsFolder, $"{_appSettings.AudioFileName}.{_appSettings.OutputAudioFormat}");

            outlook.SendMessage<TerminalMessage>(new TerminalMessage($"Начинаем конвертацию..."));
            AudioConverter.TryConvert(inputAudioPath, outputAudioPath);
            outlook.SendMessage<TerminalMessage>(new TerminalMessage($"Файл конвертирован"));

            outlook.SendMessage<TerminalMessage>(new TerminalMessage($"Начинаем распознавание..."));
            var speechText = SpeechDetector.DetectSpeech(outputAudioPath, _appSettings.InputAudioBitrate, languageCode);
            outlook.SendMessage<TerminalMessage>(new TerminalMessage($"Файл распознан."));

            return speechText;
        }
    }
}
