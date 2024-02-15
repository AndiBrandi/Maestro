using CommunityToolkit.Mvvm.ComponentModel;

using Maestro.Contracts.ViewModels;
using Maestro.Core.Contracts.Services;
using Maestro.Core.Models;

namespace Maestro.ViewModels;

public partial class PlaylistsDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private Song? item;

    public PlaylistsDetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
