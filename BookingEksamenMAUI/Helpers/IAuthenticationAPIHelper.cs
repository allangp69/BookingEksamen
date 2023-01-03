using BookingEksamenMAUI.Models;

namespace BookingEksamenMAUI.Helpers;

public interface IAuthenticationAPIHelper
{
    Task<AuthenticatedUser> Authenticate(string username, string password, string email);
}