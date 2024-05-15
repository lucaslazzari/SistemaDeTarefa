using TaskManager.Core.Enums;

namespace TaskManager.Application.ViewModels
{
    public class AssigmentViewModel
    {
        public AssigmentViewModel(int id, string? title, string? description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
    }
}
