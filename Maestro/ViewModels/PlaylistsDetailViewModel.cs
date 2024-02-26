using CommunityToolkit.Mvvm.ComponentModel;
using Maestro.Contracts.ViewModels;
using Maestro.Core.Models;

namespace Maestro.ViewModels;

public partial class PlaylistsDetailViewModel : ObservableRecipient, INavigationAware
{

    [ObservableProperty]
    private Maestro.Core.Models.Playlist? item;

    public PlaylistsDetailViewModel()
    {

    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Playlist playlist)
        {
            //var data = await _sampleDataService.GetContentGridDataAsync();
            //Item = data.First(i => i.OrderID == orderID);
            Item = playlist;

        }
    }

    public void OnNavigatedFrom()
    {
    }
}
