using TaskManager.Core.Entities;
using TaskManager.Core.Enums;

namespace TaskManager.Core.Repositories
{
    public interface IAssignmentRepository
    {
        Task<Assignment> GetByIdAsync(int id);
        Task<List<Assignment>> GetAllAsync();
        Task<List<Assignment>> GetByTitleAsync(string title);
        Task<List<Assignment>> GetByDateAsync(DateTime date);
        Task<List<Assignment>> GetByStatusAsync(EnumAssignmentStatus status);
        Task AddAsync(Assignment assignment);
        Task DeleteAsync(int id);
        Task SaveChangesAsync(Assignment assignment);      
    }
}
