using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Maestro.Contracts.ViewModels;
using Maestro.Models;

namespace Maestro.ViewModels;

public partial class LibraryViewModel : ObservableRecipient, INavigationAware
{
    //The selected Item in the left list
    [ObservableProperty]
    private Song? selected;

    public ObservableCollection<Song> AllSongs { get; private set; } = new ObservableCollection<Song>();

    public LibraryViewModel()
    {
         
    }

    public async void OnNavigatedTo(object parameter)
    {
        AllSongs.Clear();

        // TODO: Replace with real data.
        //var data = await _sampleDataService.GetListDetailsDataAsync();

        //foreach (var item in data)
        //{
        //    SampleItems.Add(item);
        //}

        //Test data
        AllSongs.Add(new Song
        {
            SongTitle = "David Guetta & Bebe Rexha - I'm Good (Blue) [Official Music Video]",
            SongDescription = "Im good david guetta original",
            SongArtists = new List<string> {"David Guetta","Bebe Rexha" },
            SongDuration = "2:57",
            SongURL = "https://www.youtube.com/watch?v=90RLzVUuXe4"
        });
        AllSongs.Add(new Song
        {
            SongTitle = "R3HAB x A Touch Of Class - All Around The World (La La La) (Alan Walker Remix) (Official Visualizer)",
            SongDescription = "Around the world rehab alan walker",
            SongArtists = new List<string> { "R3HAB", "A Touch of Class", "Alan Walker" },
            SongDuration = "2:13",
            SongURL = "https://www.youtube.com/watch?v=xWMUqEAPu-k"

        });
        AllSongs.Add(new Song
        {
            SongTitle = "Luis Fonsi - Despacito ft. Daddy Yankee",
            SongDescription = "Despacito official video",
            SongArtists = new List<string> { "Luis Fonsi", "Daddy Yankee" },
            SongDuration = "4:42",
            SongURL = "https://www.youtube.com/watch?v=kJQP7kiw5Fk",
        });
        AllSongs.Add(new Song
        {
            SongTitle = "Avicii - Levels",
            SongDescription = "Levels Original",
            SongArtists = new List<string> { "Avicii" },
            SongDuration = "3:18",
            SongURL = "https://www.youtube.com/watch?v=_ovdm2yX4MA",
        });
    }

    public void OnNavigatedFrom()
    {
    }

    public void EnsureItemSelected()
    {
        Selected ??= AllSongs.First();
    }
}
