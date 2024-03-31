using Maestro.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Maestro.Views;

public sealed partial class QueuePage : Page
{
    public QueueViewModel ViewModel
    {
        get;
    }

    public QueuePage()
    {
        ViewModel = App.GetService<QueueViewModel>();
        InitializeComponent();
    }
}