using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Maestro.Contracts.ViewModels;
using Maestro.Core.Contracts.Services;
using Maestro.Core.Models;

namespace Maestro.ViewModels;

public partial class LibraryViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private Song? selected;

    public ObservableCollection<Song> SampleItems { get; private set; } = new ObservableCollection<Song>();

    public LibraryViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        SampleItems.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data)
        {
            SampleItems.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    public void EnsureItemSelected()
    {
        Selected ??= SampleItems.First();
    }
}
