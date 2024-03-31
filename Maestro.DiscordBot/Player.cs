using Discord.Commands;
using Maestro.Core.Models;

namespace Maestro.DiscordBot;

public class Player
{
    #region EVENTS

    //TODO: Invoke for other outside sources
    public event EventHandler MusicQueueChanged;

    #endregion //EVENTS

    #region FIELDS

    private MusicQueue _musicQueue;

    private Song _currentlyPlaying;

    #endregion //FIELDS

    #region PROPERTIES

    public MusicQueue Queue
    {
        get => _musicQueue;
        set
        {
            _musicQueue = value;
            MusicQueueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion //PROPERTIES


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