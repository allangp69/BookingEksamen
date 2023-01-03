using System.Net;

namespace BookingEksamenMAUI.Helpers.Booker;

public interface IBookerAPIHelper
{
    Task<IEnumerable<Models.Booker>> GetBookersAsync();
    Task<Uri> CreateBookerAsync(Models.Booker booker);
    Task<HttpStatusCode> DeleteBookerAsync(int id);
}