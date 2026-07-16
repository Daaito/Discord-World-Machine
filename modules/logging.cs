using Discord;
using Discord.WebSocket;
public class LoggingModule : IBotModule
{

    public string Name => "Logging";
    public Task InitializeAsync(DiscordSocketClient client)
    {
        client.Log += Log;

        return Task.CompletedTask;
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg);

        return Task.CompletedTask;
    }
}