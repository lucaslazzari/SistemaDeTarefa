using Moq;
using TaskManager.Application.InputModels;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Set
{
    public class CreateAssignmentTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnAssignmentId()
        {
            // Arrange
            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();

            var createAssignmentInputModel = new CreateAssignmentInputModel()
            {
                Title = "Title",
                Description = "Description",
                Date = DateTime.Now,
            };

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);
            // Act
            var id = await assignmentService.CreateAsync(createAssignmentInputModel);
            
            // Assert
            Assert.NotNull(id);
            Assert.True(id >= 0);
            assignmentRepositoryMock.Verify(a => a.AddAsync(It.IsAny<Assignment>()), Times.Once);
        }
    }
}
