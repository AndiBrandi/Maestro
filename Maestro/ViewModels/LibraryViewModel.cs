using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maestro.Contracts.ViewModels;
using Maestro.Helpers;
using Windows.ApplicationModel.DataTransfer;
using Maestro.Core.Models;

// using Maestro.Core.Models;

namespace Maestro.ViewModels;

public partial class LibraryViewModel : ObservableRecipient, INavigationAware
{
    //The selected Item in the left list
    [ObservableProperty]
    private Maestro.Core.Models.Song? _selected;

    public ObservableCollection<Song?> AllSongs
    {
        get;
    } = new();

    public LibraryViewModel()
    {
        CommandCopyToClipboard = new RelayCommand(ExecuteCopyToClipboard);
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
        foreach (var song in SampleData.SampleSongs)
        {
            AllSongs.Add(song);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    public void EnsureItemSelected()
    {
        // Selected ??= AllSongs.First();
        Selected ??= AllSongs.First();
    }

    public ICommand CommandCopyToClipboard
    {
        get;
    }

    public void ExecuteCopyToClipboard()
    {
        DataPackage dataPackage = new();
        dataPackage.SetText(Selected?.SongURL);
        Clipboard.SetContent(dataPackage);
    }
}