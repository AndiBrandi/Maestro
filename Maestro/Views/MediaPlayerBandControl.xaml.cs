using Maestro.ViewModels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Maestro.Views;
public sealed partial class MediaPlayerBandControl : UserControl
{
    public MediaPlayerBandViewModel ViewModel
    {
        get;
    }

    public MediaPlayerBandControl()
    {
        ViewModel = App.GetService<MediaPlayerBandViewModel>();
        InitializeComponent();
    }
}
