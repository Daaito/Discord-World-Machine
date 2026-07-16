using WorldMachine.Core.Configuration;

class Programm
{
    public static async Task Main()
    {
        var settings = ConfigurationLoader.Load();

        var bot = new Bot(settings);

        await bot.StartAsync();
    }
}