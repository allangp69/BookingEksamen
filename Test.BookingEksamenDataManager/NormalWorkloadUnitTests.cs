using BookingEksamenDataManager.Controllers;

namespace Test.BookingEksamenDataManager;

public class NormalWorkloadUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NormalWorkload_GeneratesString()
    {
        //Arrange
        var controller = new NormalWorkloadController();
        //Act
        var result = controller.Get();
        var content = result?.Value;
        //Assert
        Assert.IsInstanceOf<string>(content);
    }
}