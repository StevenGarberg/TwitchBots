using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace TwitchBots.StebBot.Commands;

public interface ICommand
{
    public Task HandleCommandAsync(TwitchClient client, ChatMessage message);
}