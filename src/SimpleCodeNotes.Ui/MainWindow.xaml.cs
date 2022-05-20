using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using AvaloniaEdit;
using AvaloniaEdit.Document;
using AvaloniaEdit.Indentation.CSharp;
using AvaloniaEdit.TextMate;
using System.Collections.ObjectModel;
using TextMateSharp.Grammars;

namespace SimpleCodeNotes.Ui;

public partial class MainWindow : Window
{
    private readonly TextEditor _textEditor;
    private readonly TextMate.Installation _textMateInstallation;
    private RegistryOptions _registryOptions;
    private int _currentTheme = (int)ThemeName.LightPlus;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        _textEditor = this.FindControl<TextEditor>("Editor");
        _textEditor.Options.ShowBoxForControlCharacters = true;
        _textEditor.Options.ShowSpaces = true;
        _textEditor.Options.ShowTabs = true;
        _textEditor.Options.EnableHyperlinks = true;
        _textEditor.Options.ConvertTabsToSpaces = true;
        _textEditor.TextArea.IndentationStrategy = new CSharpIndentationStrategy(_textEditor.Options);
        _textEditor.TextArea.RightClickMovesCaret = true;

        _registryOptions = new RegistryOptions(
            (ThemeName)_currentTheme);

        _textMateInstallation = _textEditor.InstallTextMate(_registryOptions);

        var csharpLanguage = _registryOptions.GetLanguageByExtension(".cs");
        _textMateInstallation.SetGrammar(_registryOptions.GetScopeByLanguageId(csharpLanguage.Id));

        _textEditor.Document = new TextDocument("Text");

        this.AddHandler(
            PointerWheelChangedEvent,
            (o, i) =>
            {
                if (i.KeyModifiers != KeyModifiers.Control)
                {
                    return;
                }

                if (i.Delta.Y > 0)
                {
                    _textEditor.FontSize++;
                }
                else
                {
                    _textEditor.FontSize = _textEditor.FontSize > 1 ? _textEditor.FontSize - 1 : 1;
                }
            },
            RoutingStrategies.Bubble,
            true);
    }

    public ObservableCollection<string> Notes { get; set; } = new() { "1", "2" };
}