using System.Collections.ObjectModel;
using System.Printing;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maestro.Contracts.ViewModels;
using Maestro.Core.Models;
using Maestro.Helpers;

namespace Maestro.ViewModels;

public partial class PlaylistsDetailViewModel : ObservableRecipient, INavigationAware
{
    [ObservableProperty] private Playlist? item;

    [ObservableProperty] private ObservableCollection<Song> _songlist;

    [ObservableProperty] private Song _selectedSong;

    [ObservableProperty] private Song _selectedLibrarySongs;

    [ObservableProperty] private bool _isLoadingRingVisible;

    [ObservableProperty] private bool _isCheckMarkVisible;

    public ObservableCollection<Song> LibrarySongs
    {
        get
        {
            return new(SampleData.SampleSongs);
        }
    }


    public PlaylistsDetailViewModel()
    {
        IsLoadingRingVisible = false;
        IsCheckMarkVisible = false;
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Playlist playlist)
        {
            //var data = await _sampleDataService.GetContentGridDataAsync();
            //Item = data.First(i => i.OrderID == orderID);
            Item = playlist;
            Songlist = new(Item.SongList);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    public void AddItems()
    {
        //foreach(Song s in SelectedLibrarySongs)
        //{
        //    Songlist.Add(s);
        //}
        Songlist.Add(SelectedLibrarySongs);
    }

    //private bool CanExecuteDelete()
    //{

    //return false; }

    //[RelayCommand(CanExecute = nameof(CanExecuteDelete))]
    [RelayCommand]
    public void DeleteItem()
    {
        Songlist.Remove(SelectedSong);
    }

    /// <summary>
    /// 
    /// </summary>
    [RelayCommand]
    public void Save()
    {
        //IsLoadingRingVisible = true;

        //Task.Delay(1000);

        //IsLoadingRingVisible = false;
        //IsCheckMarkVisible = true;

        //Task.Delay(1000);

        //IsCheckMarkVisible = false;
    }
}