﻿using AsyncAwaitBestPractices;
using TwitchBots.StebBot.Commands;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace TwitchBots.StebBot;

public sealed class TwitchBot
{
    private readonly TwitchClient _client;

    public TwitchBot(string username, string password, string channelName)
    {
        var credentials = new ConnectionCredentials(username, password);
        var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
        var customClient = new WebSocketClient(clientOptions);
        _client = new TwitchClient(customClient);
        _client.Initialize(credentials, channelName);

        _client.OnLog += Client_OnLog;
        _client.OnJoinedChannel += Client_OnJoinedChannel;
        _client.OnMessageReceived += Client_OnMessageReceived;
        _client.OnWhisperReceived += Client_OnWhisperReceived;
        _client.OnNewSubscriber += Client_OnNewSubscriber;
        _client.OnConnected += Client_OnConnected;

        _client.Connect();
    }

    private void Client_OnLog(object sender, OnLogArgs e)
    {
        Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
    }

    private void Client_OnConnected(object sender, OnConnectedArgs e)
    {
        Console.WriteLine($"Connected to {e.AutoJoinChannel}");
    }

    private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
    {
        Console.WriteLine("Hey guys! I am a bot connected via TwitchLib!");
        _client.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
    }

    private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
        if (e.ChatMessage.Message.StartsWith("!"))
        {
            CommandHandler.HandleAsync(_client, e.ChatMessage).SafeFireAndForget();
        }

        if (e.ChatMessage.Message.Contains("badword"))
            _client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
    }

    private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
    {
        if (e.WhisperMessage.Username == "my_friend")
            _client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
    }

    private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
    {
        if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
            _client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
        else
            _client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
    }
}