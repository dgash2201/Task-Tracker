using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Task_Tracker.Services;

namespace Task_Tracker
{
    public static class LogicServicesAdder
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IProjectService, ProjectService>()
                .AddTransient<ITaskService, TaskService>();
        }
    }
}
