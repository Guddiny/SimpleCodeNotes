using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SimpleCodeNotes.Ui.Pages.Info;

public partial class InfoPageView : UserControl
{
    public InfoPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}