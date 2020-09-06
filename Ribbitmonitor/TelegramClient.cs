using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Ribbitmonitor
{
    class TelegramClient
    {
        public static void SendMessage(string message)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("settings.json", true, true).Build();
            if (string.IsNullOrEmpty(config["telegramToken"]))
            {
                return;
            }

            new Telegram.Bot.TelegramBotClient(config["telegramToken"]).SendTextMessageAsync(-252446413, message);
        }
    }
}
