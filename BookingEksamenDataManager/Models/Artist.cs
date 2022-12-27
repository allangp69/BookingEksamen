namespace BookingEksamenDataManager.Models;

public class Artist
{
    public int ArtistID { get; set; }
    public string? Name { get; set; }
    public string? ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public string? LoginID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}