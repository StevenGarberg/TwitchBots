using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace TwitchBots.StebBot.Commands;

public static class CommandHandler
{
    private static readonly Dictionary<string, ICommand> _registeredCommands = new()
    {
        { "ping", new PingCommand() },
        { "info", new InfoCommand() },
        { "konami", new KonamiCommand() },
        { "help", new HelpCommand() }
    };

    public static async Task HandleAsync(TwitchClient client, ChatMessage message)
    {
        try
        {
            var commandName = message.Message.Split(" ")[0].Replace("!", "");
            if (_registeredCommands.TryGetValue(commandName, out var command))
            {
                await command.HandleCommandAsync(client, message);
            }
            else
            {
                Console.WriteLine($"A command could not be found for \"{commandName}\"");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"An error occurred while processing the command for \"{message.Message}\"");
        }
    }
}