using Discord;
using Discord.WebSocket;
using Maestro.DiscordBot.BaseClasses;
using Maestro.DiscordBot.Interfaces;

namespace Maestro.DiscordBot.ApplicationCommands;

public class PingCommand : SlashCommandBase
{
    public override string Name => "ping";
    public override string Description => "Ping command";

    public async override Task ExecuteCommand(Bot bot, SocketSlashCommand command)
    {
        await command.RespondAsync("pong");
    }
}