﻿using System.Collections.Concurrent;
using TelegramBot.ConsoleApp.Models;

namespace TelegramBot.ConsoleApp.Services
{
    public class MemoryStorage : IStorage
    {
        /// <summary>
        /// Хранилище сессий
        /// </summary>
        private readonly ConcurrentDictionary<long, Session> _sessions;

        public MemoryStorage()
        {
            _sessions = new ConcurrentDictionary<long, Session>();
        }

        Session IStorage.GetSession(long chatId)
        {
            // Возвращаем сессию по ключу, если она существует
            if (_sessions.ContainsKey(chatId))
                return _sessions[chatId];

            // Создаем и возвращаем новую, если такой не было
            var newSession = new Session() { LanguageCode = "ru" };
            _sessions.TryAdd(chatId, newSession);
            return newSession;
        }
    }
}