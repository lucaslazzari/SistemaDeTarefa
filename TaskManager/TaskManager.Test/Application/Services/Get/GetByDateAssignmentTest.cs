using Moq;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Get
{
    public class GetByDateAssignmentTest
    {
        [Fact]
        public async Task AssignmentExistByDate_ExecutedByDate_ReturnAssignmentViewModel()
        {
            // Arrange
            var assignments = new List<Assignment>
            {
                new Assignment("teste1", "teste1", DateTime.Now),
                new Assignment("teste2", "teste2", DateTime.Now),
                new Assignment("teste3", "teste3", DateTime.Now)
            };
            var date = DateTime.Now;

            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            assignmentRepositoryMock.Setup(a => a.GetByDateAsync(date).Result).Returns(assignments);

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);

            // Act
            var assignmentViewModel = await assignmentService.GetByDateAsync(date);

            // Assert
            Assert.NotNull(assignmentViewModel);
            Assert.NotEmpty(assignmentViewModel);
            Assert.Equal(assignments.Count, assignmentViewModel.Count);

            assignmentRepositoryMock.Verify(a => a.GetByDateAsync(date).Result, Times.Once);
        }
    }
}
