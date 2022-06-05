using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SimpleCodeNotes.Ui.Pages.Settings;
public partial class SettingsPageView : UserControl
{
    public SettingsPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
