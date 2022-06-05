using Microsoft.Extensions.DependencyInjection;
using SimpleCodeNotes.DataAccess.Repositories;

namespace SimpleCodeNotes.DataAccess;
public static class DependencyIngection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string pathToDatabase)
    {
        return services
            .AddSingleton<ICodeNoteRepository>(new CodeNoteRepository(pathToDatabase));
    }
}
