using System.Reflection;
using Discord;
using Discord.Interactions;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Maestro.DiscordBot;

internal sealed class DiscordClientHost : IHostedService
{
    private readonly DiscordSocketClient _discordClient;
    private readonly InteractionService _interactionService;
    private readonly IServiceProvider _serviceProvider;

    public DiscordClientHost(DiscordSocketClient discordClient, InteractionService interactionService,
        IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(discordClient);
        ArgumentNullException.ThrowIfNull(interactionService);
        ArgumentNullException.ThrowIfNull(serviceProvider);

        _discordClient = discordClient;
        _interactionService = interactionService;
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _discordClient.InteractionCreated += InteractionCreated;
        _discordClient.Ready += Client_Ready;

        // Put bot token here
        await _discordClient
            .LoginAsync(TokenType.Bot, "")
            .ConfigureAwait(false);

        await _discordClient
            .StartAsync()
            .ConfigureAwait(false);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _discordClient.InteractionCreated -= InteractionCreated;
        _discordClient.Ready -= Client_Ready;

        await _discordClient.LogoutAsync();

        await _discordClient
            .StopAsync()
            .ConfigureAwait(false);
    }

    private Task InteractionCreated(SocketInteraction interaction)
    {
        var interactionContext = new SocketInteractionContext(_discordClient, interaction);
        return _interactionService!.ExecuteCommandAsync(interactionContext, _serviceProvider);
    }

    /// <summary>
    /// The event handler for the <see cref="DiscordSocketClient.Ready"/> event.
    /// </summary>
    /// <param name="arg">The event argument containing information about the event.</param>
    private async Task Client_Ready()
    {
        await _interactionService
            .AddModulesAsync(Assembly.GetExecutingAssembly(), _serviceProvider)
            .ConfigureAwait(false);

        // Put your guild id to test here
        await _interactionService
            .RegisterCommandsToGuildAsync(0)
            .ConfigureAwait(false);
    }
}