using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Maestro.Contracts.ViewModels;
namespace Maestro.ViewModels;

public partial class MusicbotViewModel : ObservableRecipient, INavigationAware
{
    private DiscordBot.DiscordBot Bot;

    [ObservableProperty]
    private bool _isStartEnabled;
    [ObservableProperty]
    private bool _isStopEnabled;

    public ICommand StartMusicBotCommand { get; private set; }
    public ICommand StopMusicBotCommand { get; private set; }


    public MusicbotViewModel()
    {
        StartMusicBotCommand = new RelayCommand(StartMusicBot);
        StopMusicBotCommand = new RelayCommand(StopMusicBot);
        Bot = new DiscordBot.DiscordBot();
        IsStartEnabled = true;
        IsStopEnabled = false;
    }

    private async void StartMusicBot()
    {
        Bot.Start();
        IsStartEnabled = Bot.IsRunningNegated;
        IsStopEnabled = Bot.IsRunning;
    }
    
    private void StopMusicBot()
    {
        Bot.Stop();
        IsStartEnabled = Bot.IsRunningNegated;
        IsStopEnabled = Bot.IsRunning;
    }

    public void OnNavigatedTo(object parameter)
    {
        
    }

    public void OnNavigatedFrom()
    {
        
    }
}