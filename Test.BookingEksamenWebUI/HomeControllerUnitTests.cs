using System.Security.Claims;
using BookingEksamenWebUI.Controllers;
using BookingEksamenWebUI.Helpers;
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
    public async Task HomeController_Index_Returns_ViewResult_IsSignedIn_False()
    {
        // Arrange
        var mockSignInManager = new Mock<IIsSignedInHelper>();
        var mockLogger = new Mock<ILogger<HomeController>>();
        mockSignInManager.Setup(manager => manager.IsSignedIn(It.IsAny<ClaimsPrincipal>()))
            .ReturnsAsync(false);
        var controller = new HomeController(mockSignInManager.Object, mockLogger.Object);
        
        // Act
        var result = await controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }
    
    [Test]
    public async Task HomeController_Index_Returns_ViewResult_IsSignedIn_True()
    {
        // Arrange
        var mockSignInManager = new Mock<IIsSignedInHelper>();
        var mockLogger = new Mock<ILogger<HomeController>>();
        mockSignInManager.Setup(manager => manager.IsSignedIn(It.IsAny<ClaimsPrincipal>()))
            .ReturnsAsync(true);
        var controller = new HomeController(mockSignInManager.Object, mockLogger.Object);
        
        // Act
        var result = await controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }
}