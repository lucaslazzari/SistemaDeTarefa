using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Core.Repositories;

namespace TaskManager.Infrastructure.Persistence.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        public AssignmentRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Assignment assignment)
        {
            await _dbContext.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assignment = await _dbContext.Tasks.FirstOrDefaultAsync(a => a.Id == id);
            _dbContext.Tasks.Remove(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Assignment>> GetAllAsync()
        {
            return _dbContext.Tasks.ToListAsync();
        }

        public async Task<List<Assignment>> GetByDateAsync(DateTime date)
        {
            return await _dbContext.Tasks.Where(a => a.Date == date).ToListAsync();
        }

        public async Task<Assignment> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Assignment>> GetByStatusAsync(EnumAssignmentStatus status)
        {
            return await _dbContext.Tasks.Where(a => a.Status == status).ToListAsync();
        }

        public async Task<List<Assignment>> GetByTitleAsync(string title)
        {
            return await _dbContext.Tasks.Where(a => a.Title == title).ToListAsync();
        }

        public async Task SaveChangesAsync(Assignment assignment)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
