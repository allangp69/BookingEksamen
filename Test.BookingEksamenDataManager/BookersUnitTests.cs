using BookingEksamenDataManager.Controllers;
using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Moq;

namespace Test.BookingEksamenDataManager;

public class BookersUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetBookers_ReturnsIEnumerableOfBookers()
    {
        //Arrange
        var mockBookers = new Mock<IBookers>();
        mockBookers.Setup(repo => repo.GetBookerDetails())
            .Returns(new List<Booker> {GetMockBooker()});

        var controller = new BookerController(mockBookers.Object);
        //Act
        var result = controller.Get();
        var bookers = result.Result.Value;
        //Assert
        Assert.IsInstanceOf<IEnumerable<Booker>>(bookers);
    }

    [Test]
    public void GetBookers_ReturnsOneBooker()
    {
        ///Arrange
        var mockBookers = new Mock<IBookers>();
        mockBookers.Setup(repo => repo.GetBookerDetails())
            .Returns(new List<Booker> {GetMockBooker()});
        var controller = new BookerController(mockBookers.Object);
        //Act
        var result = controller.Get();
        var bookers = result.Result.Value;
        //Assert
        Assert.IsTrue(bookers.Count() == 1);
    }

    [Test]
    public void GetSpecificBooker_ReturnsBooker()
    {
        //Arrange
        var mockBookers = new Mock<IBookers>();
        mockBookers.Setup(repo => repo.GetBookerDetails(It.Is<int>(i => i == 1 )))
            .Returns(GetMockBooker());
        var controller = new BookerController(mockBookers.Object);
        //Act
        var result = controller.Get(1);
        var booker = result.Result.Value;
        //Assert
        Assert.IsNotNull(booker);
    }

    [Test]
    public void GetNonExistingBooker_ReturnsNull()
    {
        //Arrange
        var mockBookers = new Mock<IBookers>();
        mockBookers.Setup(repo => repo.GetBookerDetails(It.Is<int>(i => i == 1 )))
            .Returns(GetMockBooker());
        var controller = new BookerController(mockBookers.Object);
        //Act
        var result = controller.Get(2);
        var booker = result.Result.Value;
        //Assert
        Assert.IsNull(booker);
    }
    
    #region Private Helpers

    private Booker GetMockBooker()
    {
        return new Booker
        {
            BookerID = 1, Name = "Great Booker", Email = "allangpedersen@yahoo.dk",
            StartDate = DateTime.Now
        };
    }
    #endregion
}