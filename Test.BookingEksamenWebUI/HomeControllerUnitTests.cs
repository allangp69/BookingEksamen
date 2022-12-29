using System.Security.Claims;
using BookingEksamen.Controllers;
using BookingEksamenUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.BookingEksamenWebUI;

public class HomeControllerUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestHomeController_Index_IsSignedIn_False()
    {
        // Arrange
        var mockSignInManager = new Mock<IIsSignedInHelper>();
        var mockLogger = new Mock<ILogger<HomeController>>();
        mockSignInManager.Setup(manager => manager.IsSignedIn(It.IsAny<ClaimsPrincipal>()))
            .Returns(false);
        var controller = new HomeController(mockSignInManager.Object, mockLogger.Object);
        
        // Act
        var result = await controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }
    
    [Test]
    public async Task TestHomeController_Index_IsSignedIn_True()
    {
        // Arrange
        var mockSignInManager = new Mock<IIsSignedInHelper>();
        var mockLogger = new Mock<ILogger<HomeController>>();
        mockSignInManager.Setup(manager => manager.IsSignedIn(It.IsAny<ClaimsPrincipal>()))
            .Returns(true);
        var controller = new HomeController(mockSignInManager.Object, mockLogger.Object);
        
        // Act
        var result = await controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }
}