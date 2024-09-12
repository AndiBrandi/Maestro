using System.Runtime.Serialization;
using Discord;
using Discord.WebSocket;
using System.Threading;
using Discord.Net;
using Lavalink4NET.Extensions;
using Maestro.DiscordBot.ApplicationCommands;
using Maestro.DiscordBot.Interfaces;
using Maestro.DiscordBot.Services;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Maestro.DiscordBot;

public class Bot
{
    #region FIELDS

    private static DiscordSocketClient _client;
    public static Player Player;
    private readonly ulong _guildId;
    private string _botToken;

    public bool IsRunning;
    public bool IsRunningNegated;

    #endregion

    #region Constructors

    /// <summary>
    /// Represents a Discord bot that can be started and stopped.
    /// </summary>
    public Bot(ulong guildId, string botToken)
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;
        _client.Ready += Client_Ready;
        _guildId = guildId;
        // _client.SlashCommandExecuted = SlashCommandHandler
        Player = new Player();
        IsRunning = false;
        IsRunningNegated = true;
        var builder = new HostApplicationBuilder();
        builder.Services.AddLavalink();
        var app = builder.Build();
        _botToken = botToken;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Starts the Discord bot.
    /// </summary>
    public async void Start()
    {
        if (_botToken == string.Empty)
            throw new InvalidOperationException("Es muss ein Token angegeben werden");

        IsRunning = true;
        IsRunningNegated = false;
        await _client.LoginAsync(TokenType.Bot, _botToken);
        await _client.StartAsync();
        await Main();
    }

    public void Stop()
    {
        _client.LogoutAsync().GetAwaiter().GetResult();
        IsRunning = false;
        IsRunningNegated = true;
    }

    #endregion

    #region Private Methods

    private async Task Main()
    {
        while (IsRunning)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles the execution of a slash command.
    /// </summary>
    /// <param name="command">The slash command to handle.</param>
    private async Task SlashCommandHandler(SocketSlashCommand command)
    {
        var command1 = CommandService.GetCommand(command.CommandName);
        command1.ExecuteCommand(this, command);
    }

    /// <summary>
    /// The event handler for the <see cref="DiscordSocketClient.Ready"/> event.
    /// </summary>
    /// <param name="arg">The event argument containing information about the event.</param>
    private async Task Client_Ready()
    {
        // Let's build a guild command! We're going to need a guild so lets just put that in a variable.
        var guild = _client.GetGuild(_guildId);

        // Next, lets create our slash command builder. This is like the embed builder but for slash commands.
        var guildCommand = new SlashCommandBuilder()
            .WithName("first-command")
            .WithDescription("This is my first guild slash command!");

        // Let's do our global command
        var globalCommand = new SlashCommandBuilder();
        globalCommand.WithName("first-global-command");
        globalCommand.WithDescription("This is my first global slash command");

        try
        {
            // Now that we have our builder, we can call the CreateApplicationCommandAsync method to make our slash command.
            await guild.CreateApplicationCommandAsync(guildCommand.Build());

            // With global commands we don't need the guild.
            await _client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
            // Using the ready event is a simple implementation for the sake of the example. Suitable for testing and development.
            // For a production bot, it is recommended to only run the CreateGlobalApplicationCommandAsync() once for each command.
        }
        catch (HttpException exception)
        {
            // If our command was invalid, we should catch an ApplicationCommandException. This exception contains the path of the error as well as the error message. You can serialize the Error field in the exception to get a visual of where your error is.
            var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);

            // You can send this error somewhere or just print it to the console, for this example we're just going to print it.
            Console.WriteLine(json);
        }
    }

    #endregion
}
