namespace BookingEksamenMAUI.Models;

public class Booker
{
    public Booker()
    {
        Artists = new List<Artist>
        {
            new Artist{Name="Artist1"},
            new Artist{Name="Artist2"}
        };
    }
    public int BookerID { get; set; }
    public string? Name { get; set; }
    public string? LoginID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? Email { get; set; }
    public IEnumerable<Artist> Artists { get; set; }
}