﻿using Lavalink4NET.Extensions;
using Maestro.Activation;
using Maestro.Contracts.Services;
using Maestro.Core.Contracts.Services;
using Maestro.Core.Services;
using Maestro.Helpers;
using Maestro.Core.Models;
using Maestro.Notifications;
using Maestro.Services;
using Maestro.ViewModels;
using Maestro.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace Maestro;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow
    {
        get;
    } = new MainWindow();

    public static UIElement? AppTitlebar
    {
        get;
        set;
    }

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().UseContentRoot(AppContext.BaseDirectory)
            .ConfigureServices((context, services) =>
            {
                // Default Activation Handler
                services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

                // Other Activation Handlers
                services.AddTransient<IActivationHandler, AppNotificationActivationHandler>();

                // Services
                services.AddSingleton<IAppNotificationService, AppNotificationService>();
                services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
                services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
                services.AddTransient<INavigationViewService, NavigationViewService>();
                services.AddSingleton<IApplicationBehaviorService, ApplicationBehaviorService>();
                services.AddSingleton<IActivationService, ActivationService>();
                services.AddSingleton<IPageService, PageService>();
                services.AddSingleton<INavigationService, NavigationService>();

                // Core Services
                services.AddSingleton<IFileService, FileService>();

                // Views
                services.AddTransient<SettingsPage>();
                services.AddTransient<PlaylistsDetailPage>();
                services.AddTransient<PlaylistsPage>();
                services.AddTransient<LibraryPage>();
                services.AddTransient<MusicbotPage>();
                services.AddTransient<QueuePage>();
                services.AddTransient<ShellPage>();
                services.AddTransient<MediaPlayerBandControl>();

                //ViewModels
                services.AddTransient<SettingsViewModel>();
                services.AddTransient<PlaylistsDetailViewModel>();
                services.AddTransient<PlaylistsViewModel>();
                services.AddTransient<ShellViewModel>();
                services.AddTransient<MusicbotViewModel>();
                services.AddTransient<QueueViewModel>();
                services.AddTransient<LibraryViewModel>();
                services.AddTransient<MediaPlayerBandViewModel>();


                // Configuration
                services.Configure<LocalSettingsOptions>(
                    context.Configuration.GetSection(nameof(LocalSettingsOptions)));
            }).Build();

        App.GetService<IAppNotificationService>().Initialize();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        //((OverlappedPresenter)App.MainWindow.Presenter).IsAlwaysOnTop = true; //This let's the window always stay on top of all other windows
        //App.GetService<IAppNotificationService>().Show(string.Format("AppNotificationSamplePayload".GetLocalized(), AppContext.BaseDirectory));

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}