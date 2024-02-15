using Maestro.Core.Models;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Maestro.Views;

public sealed partial class LibraryDetailControl : UserControl
{
    public Song? ListDetailsMenuItem
    {
        get => GetValue(ListDetailsMenuItemProperty) as Song;
        set => SetValue(ListDetailsMenuItemProperty, value);
    }

    public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(Song), typeof(LibraryDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

    public LibraryDetailControl()
    {
        InitializeComponent();
    }

    private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is LibraryDetailControl control)
        {
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
