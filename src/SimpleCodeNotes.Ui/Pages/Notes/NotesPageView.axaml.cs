using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using AvaloniaEdit;
using System.Collections.Generic;
using TextMateSharp.Grammars;
using static AvaloniaEdit.TextMate.TextMate;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public partial class NotesPageView : UserControl
{
    private readonly TextEditor _textEditor;
    private readonly Installation _textMateInstallation;
    private RegistryOptions _registryOptions;
    private int _currentTheme = (int)ThemeName.DarkPlus;

    public NotesPageView()
    {
        InitializeComponent();

        _textEditor = this.FindControl<TextEditor>("Editor");
        _textEditor.ShowLineNumbers = true;
        _textEditor.TextArea.IndentationStrategy = new AvaloniaEdit.Indentation.CSharp.CSharpIndentationStrategy(_textEditor.Options);
        _textEditor.TextArea.RightClickMovesCaret = true;
        _textEditor.ContextMenu = new ContextMenu
        {
            Items = new List<MenuItem>
                {
                    new MenuItem { Header = "Copy", InputGesture = new KeyGesture(Key.C, KeyModifiers.Control) },
                    new MenuItem { Header = "Paste", InputGesture = new KeyGesture(Key.V, KeyModifiers.Control) },
                    new MenuItem { Header = "Cut", InputGesture = new KeyGesture(Key.X, KeyModifiers.Control) }
                }
        };

        _registryOptions = new RegistryOptions(
                (ThemeName)_currentTheme);

        _textMateInstallation = _textEditor.InstallTextMate(_registryOptions);
        var csharpLanguage = _registryOptions.GetLanguageByExtension(".xml");
        _textMateInstallation.SetGrammar(_registryOptions.GetScopeByLanguageId(csharpLanguage.Id));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}