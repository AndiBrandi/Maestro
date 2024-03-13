using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Maestro.Helpers;

namespace Maestro.ViewModels;

public partial class QueueViewModel : ObservableRecipient
{

    [ObservableProperty]
    private ObservableCollection<Song> _songQueue;

    public QueueViewModel()
    {
        SongQueue = new ObservableCollection<Song>(SampleData.SampleSongs);
    }
}
