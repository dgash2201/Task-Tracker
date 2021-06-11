using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_Tracker.Entities;

namespace Task_Tracker.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private TaskTrackerDbContext _dbContext;

        public TaskRepository(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectTask>> GetAll()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<ProjectTask> Get(int id)
        {
            return await _dbContext
                .Tasks
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Add(ProjectTask task)
        {
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return task.Id;
        }

        public async Task Update(ProjectTask task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var toRemove = await _dbContext
                .Tasks
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            _dbContext.Remove(toRemove);

            await _dbContext.SaveChangesAsync();
        }
    }
}
