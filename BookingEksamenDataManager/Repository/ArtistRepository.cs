using BookingEksamenDataManager.Data;
using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamenDataManager.Repository;

public class ArtistRepository
    :IArtists
{
    private readonly DatabaseContext _databaseContext;

    public ArtistRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public List<Artist> GetArtistDetails()
    {
        return _databaseContext.Artists.ToList();
    }

    public Artist GetArtistDetails(int id)
    {
        return _databaseContext.Artists.Find(id);
    }

    public void AddArtist(Artist artist)
    {
        _databaseContext.Artists.Add(artist);
    }

    public void UpdateArtist(Artist artist)
    {
        _databaseContext.Entry(artist).State = EntityState.Modified;
        _databaseContext.SaveChanges();
    }

    public Artist DeleteArtist(int id)
    {
        var artist = _databaseContext.Artists.Find(id);

        if (artist is null)
        {
            throw new ArgumentNullException();
        }
        _databaseContext.Artists.Remove(artist);
        _databaseContext.SaveChanges();
        return artist;
    }

    public bool CheckArtist(int id)
    {
        return _databaseContext.Artists.Any(a => a.ArtistID == id);
    }
}