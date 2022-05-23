using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public partial class NotesPageView : UserControl
{
    public NotesPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}