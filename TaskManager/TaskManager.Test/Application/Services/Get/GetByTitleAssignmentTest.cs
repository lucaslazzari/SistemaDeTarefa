using Moq;
using TaskManager.Application.Services.Implementations;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Core.Repositories;

namespace TaskManager.Test.Application.Services.Get
{
    public class GetByTitleAssignmentTest
    {
        [Fact]
        public async Task AssignmentExistByTitle_ExecutedByTitle_ReturnAssignmentViewModel()
        {
            // Arrange
            var assignments = new List<Assignment>
            {
                new Assignment("teste", "teste1", DateTime.Now),
                new Assignment("teste", "teste2", DateTime.Now),
                new Assignment("teste", "teste3", DateTime.Now)
            };
            var title = "teste";

            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            assignmentRepositoryMock.Setup(a => a.GetByTitleAsync(title).Result).Returns(assignments);

            var assignmentService = new AssignmentService(assignmentRepositoryMock.Object);

            // Act
            var assignmentViewModel = await assignmentService.GetByTitleAsync(title);

            // Assert
            Assert.NotNull(assignmentViewModel);
            Assert.NotEmpty(assignmentViewModel);
            Assert.Equal(3, assignmentViewModel.Count); 
            Assert.Equal(assignments.Count, assignmentViewModel.Count);

            assignmentRepositoryMock.Verify(a => a.GetByTitleAsync(title).Result, Times.Once);
        }
    }
}
