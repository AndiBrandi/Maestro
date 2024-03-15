using System.Collections.ObjectModel;
using Maestro.Core.Models;

namespace Maestro.Helpers;

internal class SampleData
{

    public static List<Playlist> SamplePlaylists => new()
    {
        new()
    {
        PlaylistName = "Playlist1",
        PlaylistDescription = "Description1",
        SongList = SampleSongs
    },
    new()
    {
        PlaylistName = "Playlist2",
        PlaylistDescription = "Description2",
        SongList = SampleSongs
    },
   new()
    {
        PlaylistName = "Playlist3",
        PlaylistDescription = "Description3",
        SongList = SampleSongs
    },
    new() {
        PlaylistName = "Playlist4",
        PlaylistDescription = "Description4",
        SongList = SampleSongs

    },
    new() {
        PlaylistName = "Playlist5",
        PlaylistDescription = "Description4",
        SongList = SampleSongs

    },
    new() {
        PlaylistName = "Playlist6",
        PlaylistDescription = "Description4",
        SongList = SampleSongs

    },
    new() {
        PlaylistName = "Playlist7",
        PlaylistDescription = "Description4",
        SongList = SampleSongs

    },
    new() {
        PlaylistName = "Playlist8",
        PlaylistDescription = "Description4",
        SongList = SampleSongs

    },
    new() {
        PlaylistName = "Playlist9",
        PlaylistDescription = "Description4",
        SongList = SampleSongs

    },
    new() {
        PlaylistName = "Playlist10",
        PlaylistDescription = "Description4",
        SongList = SampleSongs

    },
    };

    public static List<Song> SampleSongs => new()
        {
            new Song()
            {
                SongTitle = "David Guetta & Bebe Rexha - I'm Good (Blue) [Official Music Video]",
                SongDescription = "Im good david guetta original",
                SongArtists = new List<string> { "David Guetta", "Bebe Rexha" },
                SongDuration = "2:57",
                SongURL = "https://www.youtube.com/watch?v=90RLzVUuXe4"
            },
            new()
            {
                SongTitle = "R3HAB x A Touch Of Class - All Around The World (La La La) (Alan Walker Remix) (Official Visualizer)",
                SongDescription = "Around the world rehab alan walker",
                SongArtists = new List<string> { "R3HAB", "A Touch of Class", "Alan Walker" },
                SongDuration = "2:13",
                SongURL = "https://www.youtube.com/watch?v=xWMUqEAPu-k"

            },
            new()
            {
                SongTitle = "Luis Fonsi - Despacito ft. Daddy Yankee",
                SongDescription = "Despacito official video",
                SongArtists = new List<string> { "Luis Fonsi", "Daddy Yankee" },
                SongDuration = "4:42",
                SongURL = "https://www.youtube.com/watch?v=kJQP7kiw5Fk"
            },
            new()
            {
                SongTitle = "Avicii - Levels",
                SongDescription = "Levels Original",
                SongArtists = new List<string> { "Avicii" },
                SongDuration = "3:18",
                SongURL = "https://www.youtube.com/watch?v=_ovdm2yX4MA"
            },
            new()
            {
                SongTitle = "Lost Sky - Vision pt. ll ~ Where We Started (MASHUP)",
                SongDescription = "Vision, where we started mashup",
                SongArtists = new List<string> { "Lost Sky" },
                SongDuration = "3:42",
                SongURL = "https://www.youtube.com/watch?v=0TnaERamI-Q"
            },
            new()
            {
                SongTitle = "Candyland (DR.L & JWoods Remix)",
                SongDescription = "Candyland remix",
                SongArtists = new List<string> { "Tobu", "DR.L", "JWoods" },
                SongDuration = "3:28",
                SongURL = "https://www.youtube.com/watch?v=sJxkj_gTITs"
            },
            new()
            {
                SongTitle = "Eiffel 65 - Blue (Black Lullaby Instrumental Remix 2020)",
                SongDescription = "Blue black lullaby",
                SongArtists = new List<string> { "Nightek1", "Eiffel 65" },
                SongDuration = "3:25",
                SongURL = "https://www.youtube.com/watch?v=wFL_j0cdBm4"
            },
            new()
            {
                SongTitle = "Popcorn Remix [HD]",
                SongDescription = "Popcorn remix",
                SongArtists = new List<string> { "Johnny Brave", "DJ Helli" },
                SongDuration = "6:13",
                SongURL = "https://www.youtube.com/watch?v=I3sKIV6KugA"
            },
            new()
            {
                SongTitle = "This Is What It Feels Like",
                SongDescription = "this is what it feels like",
                SongArtists = new List<string> { "Armin van Buuren", "Trevor Guthrie" },
                SongDuration = "3:24",
                SongURL = "https://www.youtube.com/watch?v=1SN3-qR3Bq0"
            },
            new()
            {
                SongTitle = "Owl City - Fireflies (Lyrics)",
                SongDescription = "fireflies",
                SongArtists = new List<string> { "Owl City" },
                SongDuration = "3:44",
                SongURL = "https://www.youtube.com/watch?v=QBgl4rVz3Ks"
            }
        };

    public static List<Song> SampleSongs2 => new()
    {
        new()
        {
            SongTitle = "NEFFEX - Numb [Copyright Free] No.77",
            SongDescription = "numb neffex",
            SongArtists = new List<string> { "Neffex" },
            SongDuration = "2:24",
            SongURL = "https://www.youtube.com/watch?v=lJkEF0_QigU"
        },
        new()
        {
            SongTitle = "Alan Walker - Alone",
            SongDescription = "alone",
            SongArtists = new List<string> { "Alan Walker" },
            SongDuration = "2:43",
            SongURL = "https://www.youtube.com/watch?v=1-xGerv5FOk"
        },
        new()
        {
            SongTitle = "Alan Walker, Dash Berlin & Vikkstar - Better Off (Alone, Pt. III) - Official Music Video ",
            SongDescription = "alone pt3",
            SongArtists = new List<string> { "Alan Walker", "Dash Berlin", "Vikkstar" },
            SongDuration = "2:31",
            SongURL = "https://www.youtube.com/watch?v=ouEl3qTLc0M"
        },
        new()
        {
            SongTitle = "TheFatRat - Unity",
            SongDescription = "unity",
            SongArtists = new List<string> { "TheFatRat" },
            SongDuration = "4:09",
            SongURL = "https://www.youtube.com/watch?v=n8X9_MgEdCg"
        },
    };
    };
