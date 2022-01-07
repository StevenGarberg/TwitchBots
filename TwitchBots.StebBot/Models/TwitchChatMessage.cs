namespace TwitchBots.StebBot.Models;

public class TwitchChatMessage : EventArgs
{
    public string Message { get; set; }
    public string Sender { get; set; }
    public string Channel { get; set; }

    public TwitchChatMessage(string message, string sender, string channel)
    {
        Message = message;
        Sender = sender;
        Channel = channel;
    }
}