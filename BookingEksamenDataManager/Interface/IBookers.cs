using BookingEksamenDataManager.Models;

namespace BookingEksamenDataManager.Interface;

public interface IBookers
{
    public List<Booker> GetBookerDetails();
    public Booker GetBookerDetails(int id);
    public void AddBooker(Booker booker);
    public void UpdateBooker(Booker booker);
    public Booker DeleteBooker(int id);
    public bool CheckBooker(int id);
}