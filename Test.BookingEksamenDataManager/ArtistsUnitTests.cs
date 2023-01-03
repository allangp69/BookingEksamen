using BookingEksamenDataManager.Controllers;
using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Moq;

namespace Test.BookingEksamenDataManager;

public class ArtistsUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetArtists_ReturnsIEnumerableOfArtist()
    {
        //Arrange
        var mockArtists = new Mock<IArtists>();
        mockArtists.Setup(repo => repo.GetArtistDetails())
            .Returns(new List<Artist>{GetMockArtist()});
        var controller = new ArtistController(mockArtists.Object);
        //Act
        var result = controller.Get();
        var artists = result.Result.Value;
        //Assert
        Assert.IsInstanceOf<IEnumerable<Artist>>(artists);
    }
    
    [Test]
    public void GetArtists_ReturnsOneArtist()
    {
        //Arrange
        var mockArtists = new Mock<IArtists>();
        mockArtists.Setup(repo => repo.GetArtistDetails())
            .Returns(new List<Artist>{GetMockArtist()});
        var controller = new ArtistController(mockArtists.Object);
        //Act
        var result = controller.Get();
        var artists = result.Result.Value;
        //Assert
        Assert.IsTrue(artists.Count() == 1);
    }
    
    [Test]
    public void GetSpecificArtist_ReturnsArtist()
    {
        //Arrange
        var mockArtists = new Mock<IArtists>();
        mockArtists.Setup(repo => repo.GetArtistDetails(It.Is<int>(i => i == 1 )))
            .Returns(GetMockArtist());
        var controller = new ArtistController(mockArtists.Object);
        //Act
        var result = controller.Get(1);
        var artist = result.Result.Value;
        //Assert
        Assert.IsNotNull(artist);
    }

    [Test]
    public void GetNonExistingArtist_ReturnsNull()
    {
        //Arrange
        var mockArtists = new Mock<IArtists>();
        mockArtists.Setup(repo => repo.GetArtistDetails(It.Is<int>(i => i == 1 )))
            .Returns(GetMockArtist());
        var controller = new ArtistController(mockArtists.Object);
        //Act
        var result = controller.Get(2);
        var artist = result.Result.Value;
        //Assert
        Assert.IsNull(artist);
    }

    #region Private helpers

    private Artist GetMockArtist()
    {
        return new Artist
        {
            ArtistID = 1, Name = "Great Artist", ShortDescription = "ShortDescription",
            LongDescription =
                "LongDescription LongDescription LongDescription LongDescription LongDescription LongDescription LongDescription LongDescription ",
            StartDate = DateTime.Now
        };
    }

    #endregion
}