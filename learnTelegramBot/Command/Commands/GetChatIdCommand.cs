using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace learnTelegramBot.Command.Commands
{
    public class GetChatIdCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "get_chat_id", "getchatid" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"ID данного чата: {message.Chat.Id}");
        }
    }
}
