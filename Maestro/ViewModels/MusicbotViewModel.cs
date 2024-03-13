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

    [ObservableProperty]
    private string _botToken;

    public MusicbotViewModel()
    {

        IsStartEnabled = true;
        IsStopEnabled = false;

        BotToken = "MTIxMTAzMDkwMjI4NTU0MTQxNg.GuA_C9._cMaUP3vpSO1XSggu83l33Z4MucrTPgLusA02U";
    }

    [RelayCommand]
    private async void StartMusicBot()
    {
        Bot = new DiscordBot.DiscordBot(685894739681345621, BotToken);
        Bot.Start();
        IsStartEnabled = Bot.IsRunningNegated;
        IsStopEnabled = Bot.IsRunning;
    }

    [RelayCommand]
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