using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_Tracker.Entities;

namespace Task_Tracker.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskTrackerDbContext _dbContext;

        public ProjectRepository(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> Get(int id)
        {
            return await _dbContext
                .Projects
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
        
        public async Task<int> Add(Project project)
        {
            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return project.Id;
        }

        public async Task Update(Project project)
        {
            _dbContext.Entry(project).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var toRemove = await _dbContext
                .Projects
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            _dbContext.Remove(toRemove);

            await _dbContext.SaveChangesAsync();
        }
    }
}
