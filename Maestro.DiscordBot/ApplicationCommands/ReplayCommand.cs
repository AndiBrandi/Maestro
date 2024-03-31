using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Maestro.DiscordBot.BaseClasses;

namespace Maestro.DiscordBot.ApplicationCommands;

public class ReplayCommand : SlashCommandBase
{
    public override string Name => "replay";

    public override string Description => "Replays the current song";

    public override Task ExecuteCommand(Bot bot, SocketSlashCommand command)
    {
        throw new NotImplementedException();
    }
}