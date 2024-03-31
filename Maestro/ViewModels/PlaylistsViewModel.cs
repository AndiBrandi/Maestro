using System.Collections.ObjectModel;
using System.Reactive;
using System.Xml;
using System.Xml.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maestro.Contracts.Services;
using Maestro.Contracts.ViewModels;
using Maestro.Core.Models;
using Maestro.Helpers;
using Maestro.Notifications;


namespace Maestro.ViewModels;

public partial class PlaylistsViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;

    public ObservableCollection<Playlist> Playlists = new();

    public PlaylistsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public void OnNavigatedTo(object parameter)
    {
        //// TODO: Replace with real data.
        //var data = await _sampleDataService.GetContentGridDataAsync();
        //foreach (var item in data)
        //{
        //    Source.Add(item);
        //}

        //TestNotification

        //Test data
        foreach (var playlist in SqliteHelper.ExecuteGetAllPlaylistsQuery())
        {
            Playlists.Add(playlist);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void ItemClicked(Playlist? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(PlaylistsDetailViewModel).FullName!, clickedItem);
        }
    }
}