using TaskManager.Application.InputModels;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Application.ViewModels;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Core.Repositories;

namespace TaskManager.Application.Services.Implementations
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<int> CreateAsync(CreateAssignmentInputModel inputModel)
        {
            var assignment = new Assignment(inputModel.Title, inputModel.Description, inputModel.Date);

            await _assignmentRepository.AddAsync(assignment);

            return assignment.Id;
        }

        public async Task DeleteAsync(int id)
        {   
            await _assignmentRepository.DeleteAsync(id);
        }

        public async Task FinishAsync(int id)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(id);

            assignment.FinishAssignment();
            await _assignmentRepository.SaveChangesAsync(assignment);
        }

        public async Task<List<AssigmentViewModel>> GetAllAsync()
        {
            var assignments = await _assignmentRepository.GetAllAsync();

            var assignmentViewModel = assignments
                .Select(a => new AssigmentViewModel(a.Id, a.Title, a.Description))
                .ToList();

            return assignmentViewModel;
        }

        public async Task<List<AssignmentDetailsViewModel>> GetByDateAsync(DateTime date)
        {
            var assignments = await _assignmentRepository.GetByDateAsync(date);

            var assignmentDetailsViewModel = assignments
                .Select(a => new AssignmentDetailsViewModel(a.Id, a.Title, a.Description, a.Date, a.Status))
                .ToList();

            return assignmentDetailsViewModel;
        }

        public async Task<AssignmentDetailsViewModel> GetByIdAsync(int id)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(id);

            var assingmentDetailsViewModel = new AssignmentDetailsViewModel(
                assignment.Id, 
                assignment.Title, 
                assignment.Description, 
                assignment.Date, 
                assignment.Status
                );

            return assingmentDetailsViewModel;
        }

        public async Task<List<AssignmentDetailsViewModel>> GetByStatusAsync(EnumAssignmentStatus status)
        {
            var assignments = await _assignmentRepository.GetByStatusAsync(status);

            var assignmentDetailsViewModel = assignments
                .Select(a => new AssignmentDetailsViewModel(a.Id, a.Title, a.Description, a.Date, a.Status))
                .ToList();

            return assignmentDetailsViewModel;
        }

        public async Task<List<AssignmentDetailsViewModel>> GetByTitleAsync(string title)
        {
            var assignments = await _assignmentRepository.GetByTitleAsync(title);

            var assignmentDetailsViewModel = assignments
                .Select(a => new AssignmentDetailsViewModel(a.Id, a.Title, a.Description, a.Date, a.Status))
                .ToList();

            return assignmentDetailsViewModel;
        }

        public async Task UpdateAsync(int id,UpdateAssignmentInputModel inputModel)
        {
            var assingment = await _assignmentRepository.GetByIdAsync(id);

            assingment.Update(inputModel.Title, inputModel.Description, inputModel.Date);

            await _assignmentRepository.SaveChangesAsync(assingment);
        }
    }
}
