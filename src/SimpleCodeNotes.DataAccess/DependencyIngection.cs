using Microsoft.Extensions.DependencyInjection;
using SimpleCodeNotes.DataAccess.Repositories;

namespace SimpleCodeNotes.DataAccess;
internal static class DependencyIngection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        return services
            .AddSingleton<ICodeNoteRepository>();
    }
}