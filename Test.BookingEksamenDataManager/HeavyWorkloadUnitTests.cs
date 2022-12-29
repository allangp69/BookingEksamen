using BookingEksamenDataManager.Controllers;

namespace Test.BookingEksamenDataManager;

public class HeavyWorkloadUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task HeavyWorkload_GeneratesString()
    {
        //Arrange
        var controller = new HeavyWorkloadController();
        //Act
        var result = controller.Get();
        var content = result?.Value;
        //Assert
        Assert.IsInstanceOf<string>(content);
    }
}