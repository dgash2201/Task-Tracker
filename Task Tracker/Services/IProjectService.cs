using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Tracker.Entities;
using Task_Tracker.Models.Requests;

namespace Task_Tracker.Services
{
    public interface IProjectService
    {
        Task<Project> Get(int id);
        Task<int> Create(ProjectRequestModel projectModel);
        Task Update(ProjectRequestModel projectModel, int id);
        Task Delete(int id);
    }
}
