namespace BookingEksamenDataManager.Models;

public class Booker
{
    public int BookerID { get; set; }
    public string? Name { get; set; }
    public string? LoginID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? Email { get; set; }
}