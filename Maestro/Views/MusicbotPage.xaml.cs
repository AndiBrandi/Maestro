using Maestro.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Maestro.Views;

public sealed partial class MusicbotPage : Page
{
    public MusicbotViewModel ViewModel
    {
        get;
    }

    public MusicbotPage()
    {
        ViewModel = App.GetService<MusicbotViewModel>();
        InitializeComponent();

    }
}
