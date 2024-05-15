using TaskManager.Core.Enums;

namespace TaskManager.Core.Entities
{
    public class Assignment
    {
        public Assignment(string? title, string? description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
            Status = EnumAssignmentStatus.Pending;
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime Date { get; private set; }
        public EnumAssignmentStatus Status { get; private set; }

        public void FinishAssignment()
        {
            if(Status == EnumAssignmentStatus.Pending)
            {
                Status = EnumAssignmentStatus.Finished;
            }
        }

        public void Update(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
        }
    }
}
