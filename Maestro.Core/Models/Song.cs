namespace Maestro.Core.Models;

public class Song
{
    #region FIELDS

    private Guid _songId;
    private string? _songTitle = "";
    private string? _songDescription = "";
    private string? _songAlbum = null;
    private List<string>? _songArtists = new();
    private TimeSpan? _songDuration = TimeSpan.Zero;
    private string? _songYoutubeUrl = "";
    private string? _thumbnailFilePath;

    #endregion //FIELDS


    #region PROPERTIES

    /// <summary>
    /// The ID of the song
    /// </summary>
    public Guid SongID
    {
        get => _songId;
        set => _songId = value;
    }

    /// <summary>
    /// The song Title
    /// </summary>
    public string? SongTitle
    {
        get => _songTitle;
        set => _songTitle = value;
    }

    /// <summary>
    /// Optional description of the Entry
    /// </summary>
    public string? SongDescription
    {
        get => _songDescription;
        set => _songDescription = value;
    }

    /// <summary>
    /// The album of the song
    /// </summary>
    public string? SongAlbum
    {
        get => _songAlbum ?? _songTitle;
        set => _songAlbum = value;
    }

    /// <summary>
    /// All Artists of the Song in a <see cref="List{String}"/>
    /// </summary>
    public List<string>? SongArtists
    {
        get => _songArtists;
        set => _songArtists = value;
    }

    /// <summary>
    /// Returns Artists as a string separated by commas (for LibraryDetailPage)
    /// </summary>
    public string? SongArtistsAsString
    {
        get
        {
            if (_songArtists != null)
            {
                return string.Join(", ", _songArtists);
            }

            return "";
        }
    }

    /// <summary>
    /// The duration of the song in Seconds
    /// </summary>
    public int? SongDuration
    {
        get => _songDuration?.Seconds;
        set => _songDuration = TimeSpan.FromSeconds(Convert.ToInt32(value));
    }

    /// <summary>
    /// The Duration of a Song in the mm:ss format
    /// </summary>
    public string? SongDurationFormatted =>
        $"{_songDuration?.Minutes}:{(_songDuration.Value.Seconds % 60).ToString("D2")}";

    /// <summary>
    /// The YouTube URL of the Song
    /// </summary>
    public string? SongURL
    {
        get => _songYoutubeUrl;
        set => _songYoutubeUrl = value;
    }

    /// <summary>
    /// The string Path to a locally stored image
    /// </summary>
    public string? ThumbnailFilePath
    {
        get => _thumbnailFilePath;
        set => _thumbnailFilePath = value;
    }

    #endregion //PROPERTIES


    #region CONSTRUCTORS

    public Song(string songTitle, string songDescription, List<string> songArtists, int songDurationSeconds,
        string youtubeUrl, string thumbnail)
    {
        _songId = Guid.NewGuid();
        _songTitle = songTitle;
        _songDescription = songDescription;
        _songArtists = songArtists;
        _songDuration = TimeSpan.FromSeconds(songDurationSeconds);
        _songYoutubeUrl = youtubeUrl;
        _thumbnailFilePath = thumbnail;
    }

    public Song()
    {
        _songId = Guid.NewGuid();
    }

    #endregion //CONSTRUCTORS

    public override string ToString()
    {
        return SongTitle;
    }
}