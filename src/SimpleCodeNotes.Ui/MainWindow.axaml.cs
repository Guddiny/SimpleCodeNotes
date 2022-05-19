using System.Collections.ObjectModel;
using Avalonia.Controls;

namespace SimpleCodeNotes.Ui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<string> Notes { get; set; } = new() { "1", "2" };
    }
}
