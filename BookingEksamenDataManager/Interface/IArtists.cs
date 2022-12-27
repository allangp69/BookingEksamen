using BookingEksamenDataManager.Models;

namespace BookingEksamenDataManager.Interface;

public interface IArtists
{
    public List<Artist> GetArtistDetails();
    public Artist GetArtistDetails(int id);
    public void AddArtist(Artist artist);
    public void UpdateArtist(Artist artist);
    public Artist DeleteArtist(int id);
    public bool CheckArtist(int id);
}