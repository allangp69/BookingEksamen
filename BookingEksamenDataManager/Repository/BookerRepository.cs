using BookingEksamenDataManager.Data;
using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamenDataManager.Repository;

public class BookerRepository
    :IBookers
{
    private readonly DatabaseContext _databaseContext;

    public BookerRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public List<Booker> GetBookerDetails()
    {
        return _databaseContext.Bookers.ToList();
    }

    public Booker GetBookerDetails(int id)
    {
        return _databaseContext.Bookers.Find(id);
    }

    public void AddBooker(Booker booker)
    {
        _databaseContext.Bookers.Add(booker);
    }

    public void UpdateBooker(Booker booker)
    {
        _databaseContext.Entry(booker).State = EntityState.Modified;
        _databaseContext.SaveChanges();
    }

    public Booker DeleteBooker(int id)
    {
        var booker = _databaseContext.Bookers.Find(id);

        if (booker is null)
        {
            throw new ArgumentNullException();
        }
        _databaseContext.Bookers.Remove(booker);
        _databaseContext.SaveChanges();
        return booker;
    }

    public bool CheckBooker(int id)
    {
        return _databaseContext.Bookers.Any(a => a.BookerID == id);
    }
}