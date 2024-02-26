using Discord;
using Discord.WebSocket;
using System.Threading;

namespace Maestro.DiscordBot;

public class DiscordBot
{

    private static string BotToken = "MTIxMTAzMDkwMjI4NTU0MTQxNg.GuA_C9._cMaUP3vpSO1XSggu83l33Z4MucrTPgLusA02U";
    public bool IsRunning;
    public bool IsRunningNegated;
    private static DiscordSocketClient _client;
    
    public DiscordBot()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;
        IsRunning = false;
        IsRunningNegated = true;
    }
    
    private async Task Main()
    {
        while (IsRunning)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    public async void Start()
    {
        IsRunning = true;
        IsRunningNegated = false;
        var token = BotToken;
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();
        await Main();
    }
    
    public void Stop()
    {
        _client.LogoutAsync().GetAwaiter().GetResult();
        IsRunning = false;
        IsRunningNegated = true;
    }
    
    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    
}