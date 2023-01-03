using BookingEksamenDataManager.Controllers;
using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Moq;

namespace Test.BookingEksamenDataManager;

public class CommentsUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetComments_ReturnsIEnumerableOfComment()
    {
        //Arrange
        var mockComments = new Mock<IComments>();
        mockComments.Setup(repo => repo.GetCommentDetails())
            .Returns(new List<Comment>{GetMockComment()});
        var controller = new CommentController(mockComments.Object);
        //Act
        var result = controller.Get();
        var comments = result.Result.Value;
        //Assert
        Assert.IsInstanceOf<IEnumerable<Comment>>(comments);
    }

    [Test]
    public void GetComments_ReturnsOneComment()
    {
        //Arrange
        var mockComments = new Mock<IComments>();
        mockComments.Setup(repo => repo.GetCommentDetails())
            .Returns(new List<Comment>{GetMockComment()});
        var controller = new CommentController(mockComments.Object);
        //Act
        var result = controller.Get();
        var comments = result.Result.Value;
        //Assert
        Assert.IsTrue(comments.Count() == 1);
    }

    #region Private Helpers

    private Comment GetMockComment()
    {
        return new Comment
        {
            LastName = "Pedersen", FirstMidName = "Allan Grønbæk", EmailAddress = "allangpedersen@yahoo.dk",
            CommentText = "Diller daller"
        };
    }

    #endregion
}