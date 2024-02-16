using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Maestro.Contracts.Services;
using Maestro.Contracts.ViewModels;
using Maestro.Core.Contracts.Services;
using Maestro.Models;

namespace Maestro.ViewModels;

public partial class PlaylistsViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;

    public ObservableCollection<Playlist> Playlists = new();

    public PlaylistsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

    }

    public async void OnNavigatedTo(object parameter)
    {
        //Source.Clear();

        //// TODO: Replace with real data.
        //var data = await _sampleDataService.GetContentGridDataAsync();
        //foreach (var item in data)
        //{
        //    Source.Add(item);
        //}

        //Test data
        Playlists.Add(new Playlist
        {
            PlaylistName = "Name1",
            PlaylistDescription = "Description1",
            SongList = new List<Song>
            {
                new()
                {
                    SongTitle = "Title1",
                }
            }
        });

    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void OnItemClick(Playlist? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(PlaylistsDetailViewModel).FullName!, clickedItem);
        }
    }
}
