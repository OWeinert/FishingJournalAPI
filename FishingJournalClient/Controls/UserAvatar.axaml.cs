using Avalonia;
using Avalonia.Controls;

namespace FishingJournal.Client.Controls
{
    public partial class UserAvatar : UserControl
    {
        public static readonly StyledProperty<string> UsernameProperty = AvaloniaProperty.Register<UserAvatar, string>(nameof(Username), defaultValue: "?");
        public string Username
        {
            get => GetValue(UsernameProperty);
            set => SetValue(UsernameProperty, value);
        }

        public UserAvatar()
        {
            InitializeComponent();
        }
    }
}
