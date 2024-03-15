using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maestro.Contracts.ViewModels;
using Maestro.Helpers;

namespace Maestro.ViewModels;

public partial class QueueViewModel : ObservableRecipient, INavigationAware
{
    [ObservableProperty]
    private List<string> _availableSources = new() { "Integrated Bot", "Extern Bot" };

    [ObservableProperty]
    private string _selectedSource;

    [ObservableProperty]
    private ObservableCollection<Song> _songQueue;

    public QueueViewModel()
    {
        SongQueue = new ObservableCollection<Song>(SampleData.SampleSongs);
    }

    public void OnNavigatedFrom()
    {
        
    }
    public void OnNavigatedTo(object parameter)
    {
        SelectedSource = AvailableSources.First();
    }

    [RelayCommand]
    public void SourceComboBox_SelectionChanged()
    {
    SongQueue.Clear();
        if (SelectedSource == null)
            throw new InvalidOperationException($"{nameof(SelectedSource)} muss einen wert haben!");
        
        if(SelectedSource!.Equals("Integrated Bot"))
        {
            SongQueue.Clear();
            //SongQueue = App.GetService<MusicbotViewModel>().Songs.ToList();
            SongQueue = new(SampleData.SampleSongs);
        } else if(SelectedSource.Equals("Extern Bot"))
        {
            SongQueue.Clear();
            SongQueue = new(SampleData.SampleSongs2);
        }


        
    }


}
