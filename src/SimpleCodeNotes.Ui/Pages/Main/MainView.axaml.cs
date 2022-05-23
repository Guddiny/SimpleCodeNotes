using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SimpleCodeNotes.Ui.Pages.Main;
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}