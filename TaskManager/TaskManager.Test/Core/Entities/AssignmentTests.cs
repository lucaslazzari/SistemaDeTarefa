using TaskManager.Core.Entities;
using TaskManager.Core.Enums;

namespace TaskManager.Test.Core.Entities
{
    public class AssignmentTests
    {
        [Fact]
        public void TestIfAssignmentFinishWorks()
        {
            var assignment = new Assignment("TitleTeste", "DescriptionTest", DateTime.Now);
            Assert.Equal(EnumAssignmentStatus.Pending, assignment.Status);

            assignment.FinishAssignment();

            Assert.Equal(EnumAssignmentStatus.Finished, assignment.Status);
        }

        [Fact]
        public void TestIfAssignmentUpdateWorks() 
        {
            var assignment = new Assignment("TitleTeste", "DescriptionTest", DateTime.Now);
            

            assignment.Update("Title2","Description2", DateTime.Now.AddDays(1));

            Assert.NotEmpty(assignment.Title);
            Assert.IsType<string>(assignment.Title);
            Assert.NotNull(assignment.Title);
            Assert.NotEmpty(assignment.Description);
            Assert.NotNull(assignment.Description);
            Assert.IsType<string>(assignment.Description);
            Assert.IsType<DateTime>(assignment.Date);
        }
    }
}
