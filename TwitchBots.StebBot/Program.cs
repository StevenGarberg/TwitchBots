using TwitchBots.StebBot;

var username = Environment.GetEnvironmentVariable("USERNAME");
var password = Environment.GetEnvironmentVariable("PASSWORD");
var channelName = Environment.GetEnvironmentVariable("CHANNEL_NAME");

var bot = new TwitchBot(username, password, channelName);
Console.ReadKey();