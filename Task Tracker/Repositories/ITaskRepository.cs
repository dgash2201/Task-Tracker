using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Tracker.Entities;

namespace Task_Tracker.Repositories
{
    public interface ITaskRepository
    {
        Task<List<ProjectTask>> GetAll();
        Task<ProjectTask> Get(int id);
        Task<int> Add(ProjectTask project);
        Task Update(ProjectTask project);
        Task Remove(int id);
    }
}
