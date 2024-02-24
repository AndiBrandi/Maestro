using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Maestro.Contracts.ViewModels;
using Maestro.DiscordBot;

namespace Maestro.ViewModels;

public partial class MusicbotViewModel : ObservableRecipient, INavigationAware
{
    private static DiscordBot.DiscordBot Bot = new();
    public ICommand StartMusicBotCommand { get; private set; }
    public ICommand StopMusicBotCommand { get; private set; }


    public MusicbotViewModel()
    {
        StartMusicBotCommand = new RelayCommand(StartMusicBot);
        StopMusicBotCommand = new RelayCommand(StopMusicBot);
    }

    private async void StartMusicBot()
    {
        await Bot.Main();
    }
    
    private void StopMusicBot()
    {
        Bot.Stop();
        
    }

    public void OnNavigatedTo(object parameter)
    {
        
    }

    public void OnNavigatedFrom()
    {
        
    }
}