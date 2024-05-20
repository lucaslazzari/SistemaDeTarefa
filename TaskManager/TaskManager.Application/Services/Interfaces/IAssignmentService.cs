using TaskManager.Application.InputModels;
using TaskManager.Application.ViewModels;
using TaskManager.Core.Enums;

namespace TaskManager.Application.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<int> CreateAsync(CreateAssignmentInputModel inputModel);
        Task UpdateAsync(int id, UpdateAssignmentInputModel inputModel);
        Task<List<AssigmentViewModel>> GetAllAsync();
        Task<AssignmentDetailsViewModel> GetByIdAsync(int id);
        Task<List<AssignmentDetailsViewModel>> GetByTitleAsync(string title);
        Task<List<AssignmentDetailsViewModel>> GetByDateAsync(DateTime date);
        Task<List<AssignmentDetailsViewModel>> GetByStatusAsync(EnumAssignmentStatus status);
        Task FinishAsync(int id);
        Task DeleteAsync(int id);
    }
}
