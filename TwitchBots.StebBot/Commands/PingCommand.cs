using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace TwitchBots.StebBot.Commands;

[Command("ping")]
public class PingCommand : ICommand
{
    public async Task HandleCommandAsync(TwitchClient client, ChatMessage message)
    {
        await Task.CompletedTask;
        client.SendMessage(message.Channel, "Pong!");
    }
}