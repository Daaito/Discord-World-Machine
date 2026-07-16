using Discord;
using Discord.WebSocket;
public class LoggingModule : IBotModule
{

    public string Name => "Logging";
    public Task InitializeAsync(DiscordSocketClient client)
    {
        //Bots Internal Logs
        client.Log += Log;

        //Server Event Logs
        client.UserJoined += UserJoined;
        client.UserLeft += UserLeft;

        client.MessageDeleted += MessageDeleted;
        client.MessageUpdated += MessageUpdated;

        client.ChannelCreated += ChannelCreated;
        client.ChannelDestroyed += ChannelDestroyed;

        return Task.CompletedTask;
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine($"[Discord] {msg}");

        return Task.CompletedTask;
    }

    private Task UserJoined(SocketGuildUser user)
    {
        Console.WriteLine($"[JOIN] {user.Username} joined {user.Guild.Name}");

        return Task.CompletedTask;
    }

    private Task UserLeft(SocketGuild guild, SocketUser user)
    {
        Console.WriteLine($"[LEAVE] {user.Username} left {guild.Name}");

        return Task.CompletedTask;
    }

    private Task MessageDeleted(Cacheable<IMessage, ulong> message,Cacheable<IMessageChannel, ulong> channel)
    {
        Console.WriteLine($"[MESSAGE DELETE] Message {message.Id} deleted in {channel.Id}");

        return Task.CompletedTask;
    }

    private Task MessageUpdated(Cacheable<IMessage, ulong> oldMessage,SocketMessage newMessage,ISocketMessageChannel channel)
    {
        Console.WriteLine($"[MESSAGE EDIT] {newMessage.Author.Username} edited a message");

        return Task.CompletedTask;
    }

    private Task ChannelCreated(SocketChannel  channel)
    {
        Console.WriteLine($"[CHANNEL CREATED] {channel.Id}");

        return Task.CompletedTask;
    }

    private Task ChannelDestroyed(SocketChannel channel)
    {
        Console.WriteLine($"[CHANNEL DELETED] {channel.Id}");

        return Task.CompletedTask;
    }
}