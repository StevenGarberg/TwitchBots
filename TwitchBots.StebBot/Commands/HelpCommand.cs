using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace TwitchBots.StebBot.Commands;

[Command("help")]
public class HelpCommand : ICommand
{
    public async Task HandleCommandAsync(TwitchClient client, ChatMessage message)
    {
        await Task.CompletedTask;
        client.SendMessage(message.Channel,
            $"The following commands can be used:" +
            "!ping - Pings the Twitch channel | " +
            "!info - Display info about the bot | " +
            "!konami - Displays the Konami code as emojis");
    }
}