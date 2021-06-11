using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Task_Tracker.Entities;
using Task_Tracker.Models.Requests;
using Task_Tracker.Repositories;

namespace Task_Tracker.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _repository;
        private ITaskService _taskService;
        private IMapper _mapper;

        public ProjectService(IProjectRepository repository, ITaskService taskService, IMapper mapper)
        {
            _repository = repository;
            _taskService = taskService;
            _mapper = mapper;
        }

        public async Task<Project> Get(int id)
        {
            var project = await _repository.Get(id);
            var tasks = await _taskService.GetAll();
            project.Tasks = tasks
                .Where(t => t.ProjectId == id)
                .ToList();

            return await _repository.Get(id);
        }

        public async Task<int> Create(ProjectRequestModel projectModel)
        {
            var project = _mapper.Map<Project>(projectModel);

            return await _repository.Add(project);
        }

        public async Task Update(ProjectRequestModel projectModel, int id)
        {
            var project = await _repository.Get(id);
            _mapper.Map(projectModel, project);

            await _repository.Update(project);
        }

        public async Task Delete(int id)
        {
           await _repository.Remove(id);
        }
    }
}
