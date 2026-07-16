using Discord.WebSocket;

public interface IBotModule
{
    string Name { get; }
    Task InitializeAsync(DiscordSocketClient client);
}