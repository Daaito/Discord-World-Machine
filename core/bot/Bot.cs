using Discord;
using Discord.WebSocket;
using WorldMachine.Core.Configuration; 

public class Bot
{
    private readonly BotSettings _settings;
    private readonly DiscordSocketClient _client;
    private readonly ModuleLoader _moduleLoader;


    public Bot(BotSettings settings)
    {
        _settings = settings;

        _client = new DiscordSocketClient(new DiscordSocketConfig{LogLevel = LogSeverity.Info});

        _moduleLoader = new ModuleLoader();
    }

    //Load modules and start bot 
    public async Task StartAsync()
    {
        await _moduleLoader.LoadModulesAsync(_client);


        //Start bot after loading modules
        await _client.LoginAsync(TokenType.Bot,_settings.DiscordToken);

        await _client.StartAsync();

        await Task.Delay(-1);
    }
}