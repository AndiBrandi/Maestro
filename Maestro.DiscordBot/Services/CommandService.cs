using Maestro.DiscordBot.ApplicationCommands;
using Maestro.DiscordBot.Interfaces;

namespace Maestro.DiscordBot.Services;

public static class CommandService
{
    // Dictionary to map string-to-Type
    private static Dictionary<string, Type> commandDict = new()
    {
        { "ping", typeof(PingCommand) },
        { "play", typeof(PlayCommand) }
    };

    // Method to create command instances dynamically
    public static ISlashCommand GetCommand(string commandName)
    {
        if (commandDict.TryGetValue(commandName, out Type commandType))
        {
            return (ISlashCommand)Activator.CreateInstance(commandType);
        }

        throw new ArgumentException("Invalid command type");
    }
}