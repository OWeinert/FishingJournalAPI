using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FishingJournal.Client.Api;
using FishingJournal.Client.Services;
using FishingJournalClient.ViewModels;
using FishingJournalClient.Views;
using ReactiveUI;
using Splat;

namespace FishingJournalClient;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        // Services

        SplatRegistrations.RegisterLazySingleton<IAsynchronousClient, ApiClient>("Init");
        SplatRegistrations.RegisterLazySingleton<IJournalEntryService, JournalEntryService>("Init");

        // ViewModels
        SplatRegistrations.Register<MainViewModel>("Init");

        SplatRegistrations.SetupIOC();

        Locator.CurrentMutable.InitializeSplat();
        Locator.CurrentMutable.InitializeReactiveUI();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
