namespace TaskManager.Application.InputModels
{
    public class UpdateAssignmentInputModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime date { get; set; }
    }
}
