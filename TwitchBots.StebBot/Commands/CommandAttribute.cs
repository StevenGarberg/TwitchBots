namespace TwitchBots.StebBot.Commands;

public sealed class CommandAttribute : Attribute
{
    public string Name { get; private set; }

    public CommandAttribute(string name)
    {
        Name = name;
    }
}