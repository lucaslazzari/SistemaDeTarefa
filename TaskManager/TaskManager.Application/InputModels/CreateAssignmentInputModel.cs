﻿namespace TaskManager.Application.InputModels
{
    public class CreateAssignmentInputModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}
