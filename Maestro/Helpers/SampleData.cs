using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maestro.Models;

namespace Maestro.Helpers
{
    class SampleData
    {

        public static List<Playlist> SamplePlaylists => new List<Playlist>()
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
                }
            };
    };

}
