using System.Text.Json;

namespace WorldMachine.Core.Configuration;

public static class ConfigurationLoader
{
    private const string DefaultConfigPath = "Core/Configuration/Env/appsettings.json";

    public static BotSettings Load()
    {
        return Load(DefaultConfigPath);
    }
    public static BotSettings Load(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"No Configuration File found at: {path} :<");
        }
        string json = File.ReadAllText(path);

        BotSettings? settings = JsonSerializer.Deserialize<BotSettings>(json);

        if (settings is null)
        {
            throw new Exception("Could not deserialize configuration.");
        }
        return settings;
    }
}