using Discord;
using Discord.WebSocket;
using Maestro.DiscordBot.Interfaces;

namespace Maestro.DiscordBot.BaseClasses;

/// <summary>
/// The base class for Slash Commands.
/// </summary>
public abstract class SlashCommandBase : ISlashCommand
{
    /// <inheritdoc/>
    public abstract string Name
    {
        get;
    }

    /// <inheritdoc/>
    public abstract string Description
    {
        get;
    }

    /// <inheritdoc/>
    public virtual SlashCommandBuilder CommandBuilder
    {
        get => new SlashCommandBuilder().WithName(Name).WithDescription(Description);
    }

    /// <inheritdoc/>
    public abstract Task ExecuteCommand(DiscordBot bot, SocketSlashCommand command);
}