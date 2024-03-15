using Discord.WebSocket;
using Maestro.DiscordBot.BaseClasses;

namespace Maestro.DiscordBot.ApplicationCommands;


public class PlayCommand : SlashCommandBase
{
    
    public override string Name => "play";
    public override string Description => "Play a song.";
    public override async Task ExecuteCommand(Bot bot, SocketSlashCommand command)
    {
        // Code to handle the execution of the play command
    }
    
}