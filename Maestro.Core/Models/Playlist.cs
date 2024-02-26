namespace Maestro.Core.Models;

public class Playlist
{
    #region FIELDS

    private readonly Guid _playlistID = Guid.NewGuid();
    private string? _playlistName;
    private string? _playlistDescription;
    private List<Song>? _songList;

    #endregion //FIELDS

    #region PROPERTIES

    public Guid PlaylistID => _playlistID; //get ID

    public string? PlaylistName
    {
        get => _playlistName;
        set => _playlistName = value;
    }

    public string? PlaylistDescription
    {
        get => _playlistDescription;
        set => _playlistDescription = value;
    }

    public List<Song>? SongList
    {
        get => _songList;
        set => _songList = value;
    }

    public int SongCount
    {
        get
        {
            if (_songList != null)
            {
                return _songList.Count;
            }

            return 0;
        }
    }

    #endregion //PROPERTIES

    #region CONSTRUCTORS

    //public Playlist()
    //{
    //}

    public Playlist(string playlistName, string playlistDescription, List<Song> songList)
    {
        _playlistName = playlistName;
        _playlistDescription = playlistDescription;
        _songList = songList;
    }

    public Playlist()
    {
        _playlistID = Guid.NewGuid();
    }

    #endregion //CONSTRCUTORS
}