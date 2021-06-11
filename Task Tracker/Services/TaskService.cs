using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Tracker.Entities;
using Task_Tracker.Models.Requests;
using Task_Tracker.Repositories;

namespace Task_Tracker.Services
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _repository;
        private IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _repository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectTask>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ProjectTask> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<int> Create(TaskRequestModel taskModel)
        {
            var task = _mapper.Map<ProjectTask>(taskModel);

            return await _repository.Add(task);
        }

        public async Task Update(TaskRequestModel taskModel, int id)
        {
            var task = await _repository.Get(id);
            _mapper.Map(taskModel, task);

            await _repository.Update(task);
        }

        public async Task Delete(int id)
        {
            await _repository.Remove(id);
        }
    }
}
