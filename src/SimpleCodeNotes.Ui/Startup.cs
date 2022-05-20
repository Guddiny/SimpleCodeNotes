using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCodeNotes.Ui.ViewModel;

namespace SimpleCodeNotes.Ui;

public class Startup
{
    public IConfiguration? Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
    }
}