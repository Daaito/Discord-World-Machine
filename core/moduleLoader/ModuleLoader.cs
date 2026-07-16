using Discord.WebSocket;

public class ModuleLoader
{
    private readonly List<IBotModule> _modules;


    public ModuleLoader()
    {
        _modules = new List<IBotModule>();
    }


    public async Task LoadModulesAsync(DiscordSocketClient client)
    {
        /*
        add future modules manually
        _modules.Add(new ...); 
        */
        _modules.Add(new LoggingModule());


        foreach(var module in _modules)
        {
            Console.WriteLine($"Loading module: {module.Name}");

            await module.InitializeAsync(client);
        }
    }
}