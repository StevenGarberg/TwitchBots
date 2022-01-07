using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace TwitchBots.StebBot.Commands;

[Command("konami")]
public class KonamiCommand : ICommand
{
    public async Task HandleCommandAsync(TwitchClient client, ChatMessage message)
    {
        await Task.CompletedTask;
        client.SendMessage(message.Channel, "⬆⬆⬇⬇⬅➡⬅➡🅱🅰");
    }
}