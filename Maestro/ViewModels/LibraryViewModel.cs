using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Discord.Rest;
using Maestro.Contracts.ViewModels;
using Maestro.Helpers;
using Windows.ApplicationModel.DataTransfer;

// using Maestro.Core.Models;

namespace Maestro.ViewModels;

public partial class LibraryViewModel : ObservableRecipient, INavigationAware
{
    //The selected Item in the left list
    [ObservableProperty] private Song? _selected;

    public ObservableCollection<Song?> AllSongs
    {
        get;
    } = new();

    public LibraryViewModel()
    {
    }

    public void OnNavigatedTo(object parameter)
    {
        AllSongs.Clear();

        // TODO: Replace with real data.
        //var data = await _sampleDataService.GetListDetailsDataAsync();

        //foreach (var item in data)
        //{
        //    SampleItems.Add(item);
        //}


        //Test data
        foreach (var song in SqliteHelper.ExecuteGetAllSongsQuery())
        {
            AllSongs.Add(song);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    public void EnsureItemSelected()
    {
        Selected ??= AllSongs.First();
    }

    public ICommand CommandCopyToClipboard
    {
        get;
    }

    [RelayCommand]
    public void CopyToClipboard()
    {
        DataPackage dataPackage = new();
        dataPackage.SetText(Selected?.SongURL);
        Clipboard.SetContent(dataPackage);
    }

    [RelayCommand]
    public void AddNewSong()
    {
    }

    [RelayCommand]
    public void DeleteSong()
    {
    }

    [RelayCommand]
    public void ShowLibraryStatistics()
    {
    }
}