using Moq;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Get
{
    public class GetByIdAssignmentTest
    {
        [Fact]
        public async Task AssignmentIdExist_ExecutedById_ReturnAssignmentViewModel()
        {
            // Arrange
            var assignment = new Assignment("teste", "teste", DateTime.Now);

            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            assignmentRepositoryMock.Setup(a => a.GetByIdAsync(assignment.Id).Result).Returns(assignment);

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);

            // Act
            var assignmentViewModel = await assignmentService.GetByIdAsync(assignment.Id);

            // Assert
            Assert.NotNull(assignmentViewModel);
            Assert.Equal(assignment.Id, assignmentViewModel.Id);
            Assert.Equal(assignment.Title, assignmentViewModel.Title);
            Assert.Equal(assignment.Description, assignmentViewModel.Description);
            Assert.Equal(assignment.Status, assignmentViewModel.Status);
            Assert.Equal(assignment.Date, assignmentViewModel.Date);


            assignmentRepositoryMock.Verify(a => a.GetByIdAsync(assignment.Id).Result, Times.Once);
        }
    }
}
