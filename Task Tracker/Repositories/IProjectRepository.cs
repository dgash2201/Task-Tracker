using System.Threading.Tasks;
using Task_Tracker.Entities;

namespace Task_Tracker.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> Get(int id);
        Task<int> Add(Project project);
        Task Update(Project project);
        Task Remove(int id);
    }
}
