using BookingEksamenWebUI.Controllers;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.BookingEksamenWebUI;

public class CommentControllerUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task CommentController_Index_ReturnsViewResultWithListOfComments()
    {
        // Arrange
        var mockCommentAPIHelper = new Mock<ICommentAPIHelper>();
        var listOfComments = new List<Comment>
        {
            new Comment{ LastName = "Pedersen", FirstMidName = "Allan", EmailAddress = "allan@pedersen.dk", CommentText = "Dette er en kommentar"},
            new Comment{ LastName = "Johnson", FirstMidName = "John", EmailAddress = "john@johnson.dk", CommentText = "Dette er en endnu en kommentar"}
        };
        mockCommentAPIHelper.Setup(helper => helper.GetCommentsAsync())
            .ReturnsAsync(listOfComments);
        var mockLogger = new Mock<ILogger<CommentController>>();
        var controller = new CommentController(mockCommentAPIHelper.Object, mockLogger.Object);
        
        // Act
        var result = await controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.IsInstanceOf<IEnumerable<Comment>>(viewResult.ViewData.Model);
        var model = viewResult.ViewData.Model as IEnumerable<Comment>;
        Assert.AreEqual(2, model.Count());
    }
}