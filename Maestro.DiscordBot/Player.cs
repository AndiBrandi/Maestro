using Discord.Commands;

namespace Maestro.DiscordBot;

public class Player
{

    private MusicQueue _musicQueue;
    
    public Player()
    {
        _musicQueue = new MusicQueue();
    }

    public void Play()
    {
        
    }

    public void Skip()
    {
        
    }
    
    public void Stop()
    {
        _musicQueue.ClearQueue();
    }
    
    
    
}