using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Helpers;

public interface IAuthenticationAPIHelper
{
    Task<AuthenticatedUser> Authenticate(string username, string password, string email);
}