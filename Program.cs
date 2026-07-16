using WorldMachine.Core.Configuration;
using Discord.WebSocket;
using Discord; 

class Programm
{
    public static async Task Main()
    {
        var settings = ConfigurationLoader.Load();

        var bot = new Bot(settings);

        await bot.StartAsync();
    }
}