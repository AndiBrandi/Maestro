using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace Maestro.Models;

public class Song
{
    #region FIELDS

    private Guid _songID;
    private string? _songTitle = "";
    private string? _songDescription = "";
    private List<string>? _songArtists = new();
    private string? _songDuration = "";
    private string? _songYoutubeURL = "";
    private Image? _thumbnail;

    #endregion //FIELDS


    #region PROPERTIES

    public Guid SongID
    {
        get => _songID;
        set => _songID = value;
    }

    public string? SongTitle
    {
        get => _songTitle;
        set => _songTitle = value;
    }

    public string? SongDescription
    {
        get => _songDescription;
        set => _songDescription = value;
    }

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

    public string? SongDuration
    {
        get => _songDuration;
        set => _songDuration = value;
    }

    public string? SongURL
    {
        get => _songYoutubeURL;
        set => _songYoutubeURL = value;
    }
    public Image? Thumbnail
    {
        get => _thumbnail;
        set => _thumbnail = value;
    }

    #endregion //PROPERTIES


    #region CONSTRUCTORS

    public Song(string songTitle, string songDescription, List<string> songArtists, string songDuration, string youtubeUrl, Image thumbnail)
    {
        _songID = Guid.NewGuid();
        _songTitle = songTitle;
        _songDescription = songDescription;
        _songArtists = songArtists;
        _songDuration = songDuration;
        _songYoutubeURL = youtubeUrl;
        _thumbnail = thumbnail;
        
    }

    public Song()
    {
        _songID = Guid.NewGuid();
    }


    #endregion //CONSTRUCTORS

}
