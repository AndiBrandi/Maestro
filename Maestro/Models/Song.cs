using System;
using System.Collections.Generic;
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
    private string? _songTitle;
    private string? _songDescription;
    private List<string>? _songArtists;
    private string? _songDuration;
    private string? _songYoutubeURL;
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

    public Song(string songTitle, string songDescription, List<string> songArtist, string songDuration, string youtubeUrl, Image thumbnail)
    {
        SongTitle = songTitle;
        SongDescription = songDescription;
        SongArtists = songArtist;
        SongDuration = songDuration;
        SongURL = youtubeUrl;
        Thumbnail = thumbnail;
        
    }

    public Song()
    {
        _songID = Guid.NewGuid();
    }



    #endregion //CONSTRUCTORS

}
