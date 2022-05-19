using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaEdit;
using AvaloniaEdit.Document;
using AvaloniaEdit.Indentation.CSharp;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace SimpleCodeNotes.Ui
{
    public partial class MainWindow : Window
    {
        private readonly TextEditor _textEditor;
        private readonly TextMate.Installation _textMateInstallation;
        private RegistryOptions _registryOptions;
        private int _currentTheme = (int)ThemeName.DarkPlus;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _textEditor = this.FindControl<TextEditor>("Editor");
            _textEditor.Background = Brushes.Transparent;
            _textEditor.ShowLineNumbers = true;
            _textEditor.TextArea.Background = this.Background;
            _textEditor.Options.ShowBoxForControlCharacters = true;
            _textEditor.TextArea.IndentationStrategy = new CSharpIndentationStrategy(_textEditor.Options);
            _textEditor.TextArea.RightClickMovesCaret = true;

            _registryOptions = new RegistryOptions(
                (ThemeName)_currentTheme);

            _textMateInstallation = _textEditor.InstallTextMate(_registryOptions);
            Language csharpLanguage = _registryOptions.GetLanguageByExtension(".cs");
            string scopeName = _registryOptions.GetScopeByLanguageId(csharpLanguage.Id);
            _textMateInstallation.SetGrammar(_registryOptions.GetScopeByLanguageId(csharpLanguage.Id));

            _textEditor.Document = new TextDocument("Text");
        }

        public ObservableCollection<string> Notes { get; set; } = new() { "1", "2" };
    }
}
