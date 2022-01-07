using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace TwitchBots.StebBot.Commands;

[Command("info")]
public class InfoCommand : ICommand
{
    public async Task HandleCommandAsync(TwitchClient client, ChatMessage message)
    {
        await Task.CompletedTask;
        client.SendMessage(message.Channel, "I am built with .NET 6 and the TwitchLib library. " +
                                            "I was built live on stream on January 4, 2022.");
    }
}