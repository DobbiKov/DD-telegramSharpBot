using learnTelegramBot.Command.Commands;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace learnTelegramBot
{
    class Program
    {
        private static TelegramBotClient client;
        private static List<Command.Command> commands;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(Config.Token);

            commands = new List<Command.Command>();
            commands.Add(new GetMyIdCommand());
            commands.Add(new GetChatIdCommand());

            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.WriteLine("[Log]: Bot started");
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if(message.Text != null)
            {
                Console.WriteLine($"[Log]: Пришло новое сообщение! От:{message.From.FirstName} {message.From.LastName} с текстом: {message.Text}");

                foreach(var comm in commands)
                {
                    if (comm.Contains(message.Text))
                    {
                        comm.Execute(message, client);
                    }
                }
            }
        }
    }
}
