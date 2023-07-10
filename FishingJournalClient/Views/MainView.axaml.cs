using Avalonia.Controls;
using Avalonia.Interactivity;
using FishingJournalClient.ViewModels;
using ReactiveUI;
using Splat;
using System.Threading.Tasks;

namespace FishingJournalClient.Views;

public partial class MainView : UserControl, IViewFor<MainViewModel>
{
    public MainViewModel? ViewModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    object? IViewFor.ViewModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public MainView()
    {
        DataContext = Locator.Current.GetService<MainViewModel>();
        InitializeComponent();
    }

    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
    }
}
