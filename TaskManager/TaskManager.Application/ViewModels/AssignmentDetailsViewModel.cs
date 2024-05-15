using TaskManager.Core.Enums;

namespace TaskManager.Application.ViewModels
{
    public class AssignmentDetailsViewModel
    {
        public AssignmentDetailsViewModel(int id, string? title, string? description, DateTime date, EnumAssignmentStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            Status = status;
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime Date { get; private set; }
        public EnumAssignmentStatus Status { get; private set; }
    }
}
