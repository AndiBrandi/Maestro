using Discord;
using Discord.WebSocket;
using Discord.Commands.Builders;

namespace Maestro.DiscordBot.Interfaces;

/// <summary>
/// Interface for defining a slash command.
/// </summary>
public interface ISlashCommand
{
    /// <summary>
    /// The name of a slash command.
    /// </summary>
    /// <remarks>
    /// The name is a required property for defining a slash command.
    /// </remarks>
    string Name
    {
        get;
    }

    /// <summary>
    /// The description of an Slash Command
    /// </summary>
    string Description
    {
        get;
    }

    /// <summary>
    /// Represents a standard Slash Command with Name and Description.
    /// <remarks>Override this to add more functionality to your command</remarks>
    /// </summary>
    SlashCommandBuilder CommandBuilder
    {
        get => new SlashCommandBuilder().WithName(Name).WithDescription(Description);
    }

    /// <summary>
    /// Executes the given Slash command
    /// </summary>
    /// <param name="bot">The Discord bot instance.</param>
    /// <param name="command">The slash command to execute.</param>
    Task ExecuteCommand(Bot bot, SocketSlashCommand command);
}