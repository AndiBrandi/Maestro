using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Maestro.DiscordBot.BaseClasses;

namespace Maestro.DiscordBot.ApplicationCommands;

public class SkipCommand : SlashCommandBase
{
    public override string Name => "skip";

    public override string Description => "Skips the current playing song";

    public override Task ExecuteCommand(Bot bot, SocketSlashCommand command)
    {
        throw new NotImplementedException();
    }
}