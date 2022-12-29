using System.Net;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers;

public interface IBookerAPIHelper
{
    Task<IEnumerable<Booker>> GetBookersAsync();
    Task<Uri> CreateBookerAsync(Booker booker);
    Task<HttpStatusCode> DeleteBookerAsync(int id);
}