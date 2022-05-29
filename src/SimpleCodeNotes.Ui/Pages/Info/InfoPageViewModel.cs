using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Settings;

namespace SimpleCodeNotes.Ui.Pages.Info;

public class InfoPageViewModel : BaseViewModel
{
    public InfoPageViewModel(AppSettings appSettings)
    {
        AppSettings = appSettings;
    }

    public AppSettings AppSettings { get; set; }
}