using Moq;
using TaskManager.Application.InputModels;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Set
{
    public class UpdateAssigmentTest
    {
        [Fact]
        public async Task AssignmentExist_ExecutedUpdate_ReturnAssignmentAfterUpdate()
        {
            // Arrange
            var assignment = new Assignment("test", "test", DateTime.Now);
            var assignmentUpdate = new UpdateAssignmentInputModel() 
            {
                Title = "testUpdate",
                Description = "Description",
                Date = DateTime.Now,
            };

            var assignmentRepositoryMock = new Mock<IAssignmentRepository>(); 
            assignmentRepositoryMock.Setup(a => a.GetByIdAsync(assignment.Id)).ReturnsAsync(assignment);

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);
            
            // Act
            await assignmentService.UpdateAsync(assignment.Id, assignmentUpdate);

            // Assert
            Assert.NotNull(assignment);
            Assert.Equal("testUpdate", assignment.Title);
            Assert.Equal(assignmentUpdate.Title, assignment.Title);
            Assert.Equal("Description", assignment.Description);
            Assert.Equal(assignmentUpdate.Description, assignment.Description);
            Assert.Equal(assignmentUpdate.Date, assignment.Date);

            assignmentRepositoryMock.Verify(pr => pr.GetByIdAsync(assignment.Id), Times.Once);
            assignmentRepositoryMock.Verify(pr => pr.SaveChangesAsync(It.IsAny<Assignment>()), Times.Once);
        }
    }
}
