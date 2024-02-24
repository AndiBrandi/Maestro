using Discord;
using Discord.WebSocket;
using System.Threading;

namespace Maestro.DiscordBot;

public class DiscordBot
{

    private static string BotToken = "MTIxMTAzMDkwMjI4NTU0MTQxNg.GuA_C9._cMaUP3vpSO1XSggu83l33Z4MucrTPgLusA02U";
    private static bool IsRunning = true;
    private static DiscordSocketClient _client;
    
    public async Task Main()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;

        var token = BotToken;
        
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

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

    public void Stop()
    {
        _client.LogoutAsync().GetAwaiter().GetResult();
        IsRunning = false;
    }
    
}