using Moq;
using TaskManager.Application.InputModels;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Set
{
    public class DeleteAssignmentTest
    {
        [Fact]
        public async Task AssignmentExist_ExecutedDelete_ReturnDeleteAssignment()
        {
            // Arrange
            var assignment = new Assignment("test", "test", DateTime.Now);

            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            assignmentRepositoryMock.Setup(a => a.GetByIdAsync(assignment.Id)).ReturnsAsync(assignment);

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);

            // Act
            await assignmentService.DeleteAsync(assignment.Id);

            // Assert

            assignmentRepositoryMock.Verify(pr => pr.DeleteAsync(assignment.Id), Times.Once);
        }
    }
}
