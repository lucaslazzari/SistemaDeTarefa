using Moq;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Get
{
    public class GetAllAssignmentTest
    {
        [Fact]
        public async Task ThreeAssigmentsExist_Executed_ReturnThreeAssigmentsViewModel()
        {
            // Arrange
            var assignments = new List<Assignment>
            {
                new Assignment("teste1", "teste1", DateTime.Now),
                new Assignment("teste2", "teste2", DateTime.Now),
                new Assignment("teste3", "teste3", DateTime.Now)
            };

            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            assignmentRepositoryMock.Setup(a => a.GetAllAsync().Result).Returns(assignments);

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);
            // Act
            var assignmentViewModel = await assignmentService.GetAllAsync();
            // Assert
            Assert.NotNull(assignmentViewModel);
            Assert.NotEmpty(assignmentViewModel);
            Assert.Equal(assignments.Count, assignmentViewModel.Count);

            assignmentRepositoryMock.Verify(a => a.GetAllAsync().Result, Times.Once());    
        }
        // Arrange
        // Act
        // Assert
    }
}
