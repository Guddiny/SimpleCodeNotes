using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaEdit;
using AvaloniaEdit.Indentation.CSharp;
using TextMateSharp.Grammars;
using static AvaloniaEdit.TextMate.TextMate;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public partial class NotesPageView : UserControl
{
    private readonly TextEditor _textEditor;
    private readonly ComboBox _syntaxList;
    private readonly Installation _textMateInstallation;
    private readonly RegistryOptions _registryOptions;

    public NotesPageView()
    {
        InitializeComponent();

        _textEditor = this.FindControl<TextEditor>("Editor");
        _syntaxList = this.FindControl<ComboBox>("SupportedSyntax");

        _textEditor.ShowLineNumbers = true;
        _textEditor.Options.HighlightCurrentLine = true;
        _textEditor.TextArea.IndentationStrategy = new CSharpIndentationStrategy(_textEditor.Options);
        _textEditor.TextArea.RightClickMovesCaret = true;

        _registryOptions = new RegistryOptions(ThemeName.DarkPlus);
        _syntaxList.Items = _registryOptions.GetAvailableLanguages();
        _syntaxList.SelectionChanged += SyntaxList_SelectionChanged;

        _textMateInstallation = _textEditor.InstallTextMate(_registryOptions);
        var csharpLanguage = _registryOptions.GetLanguageByExtension(".xml");
        _textMateInstallation.SetGrammar(_registryOptions.GetScopeByLanguageId(csharpLanguage.Id));

        AddMouseZoom();
    }

    private void SyntaxList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var language = (Language)_syntaxList.SelectedItem!;
        string scopeName = _registryOptions.GetScopeByLanguageId(language.Id);

        _textMateInstallation.SetGrammar(null);

        // _textEditor.Document = new TextDocument(ResourceLoader.LoadSampleFile(scopeName));
        _textMateInstallation.SetGrammar(scopeName);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddMouseZoom()
    {
        AddHandler(
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
}
