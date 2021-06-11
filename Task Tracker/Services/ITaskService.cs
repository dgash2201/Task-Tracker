using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Tracker.Entities;
using Task_Tracker.Models.Requests;

namespace Task_Tracker.Services
{
    public interface ITaskService
    {
        Task<List<ProjectTask>> GetAll();
        Task<ProjectTask> Get(int id);
        Task<int> Create(TaskRequestModel projectModel);
        Task<int> Update(TaskRequestModel projectModel, int id);
        Task Delete(int id);
    }
}
