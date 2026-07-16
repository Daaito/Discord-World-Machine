using WorldMachine.Core.Configuration;
using Discord.WebSocket;
using Discord; 

class Programm
{
    private static DiscordSocketClient _client = null!;
    
    //Simple logging by discord dotnet example
    private static Task Log(LogMessage message)
    {
        Console.WriteLine(message);
        return Task.CompletedTask;
    }
    private static Task Ready()
    {
        Console.WriteLine($"Connected as {_client.CurrentUser.Username}");
        return Task.CompletedTask;
    }
    public static async Task Main()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;
        _client.Ready += Ready;

        //Load configuration and API key
        BotSettings settings = ConfigurationLoader.Load();
        var token = settings.DiscordToken;
        if (string.IsNullOrWhiteSpace(token)) throw new Exception("Discord token is missing.");

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }
}