using Microsoft.Extensions.DependencyInjection;
using Task_Tracker.Repositories;

namespace Task_Tracker
{
    public static class RepositoriesAdder
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
             return serviceCollection
                .AddTransient<IProjectRepository, ProjectRepository>()
                .AddTransient<ITaskRepository, TaskRepository>();
        }
    }
}
