using Moq;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Set
{
    public class FinishAssignmentTest
    {
        [Fact]
        public async Task AssignmentExist_Executedinish_ReturnStatusEnumFinished()
        {
            // Arrange
            var assignment = new Assignment("test", "test", DateTime.Now);

            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            assignmentRepositoryMock.Setup(a => a.GetByIdAsync(assignment.Id)).ReturnsAsync(assignment);

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);

            // Act
            await assignmentService.FinishAsync(assignment.Id);

            // Assert
            Assert.Equal(EnumAssignmentStatus.Finished, assignment.Status);
            assignmentRepositoryMock.Verify(pr => pr.SaveChangesAsync(It.IsAny<Assignment>()), Times.Once);
        }
    }
}
