using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maestro.Contracts.ViewModels;

namespace Maestro.ViewModels;
public partial class MediaPlayerBandViewModel : ObservableRecipient, INavigationAware
{

    //public ICommand ReplayCommand;
    //public ICommand PlayCommand;
    //public ICommand SkipCommand;

    [ObservableProperty]
    private Song _currentSong;

    public MediaPlayerBandViewModel()
    {

        replayClickedCommand = new RelayCommand(ReplayClicked);
        playClickedCommand = new RelayCommand(PlayClicked);
        skipClickedCommand = new RelayCommand(SkipClicked);


        //TEST DATA
        CurrentSong = new()
        {
            SongTitle = "I'm Good (Blue)",
            SongArtists = { "David Guetta", "Bebe Rexha" },
            SongAlbum = null,
        };

    }

    public void OnNavigatedFrom()
    {

    }
    public void OnNavigatedTo(object parameter)
    {

    }

    [RelayCommand]
    private void ReplayClicked()
    {

    }

    [RelayCommand]
    private void PlayClicked()
    {

    }

    [RelayCommand]
    private void SkipClicked()
    {

    }


}
