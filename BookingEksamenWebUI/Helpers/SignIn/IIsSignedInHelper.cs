using System.Security.Claims;

namespace BookingEksamenWebUI.Helpers;

public interface IIsSignedInHelper
{
    Task<bool> IsSignedIn(ClaimsPrincipal user);
    Task<bool> IsInRole(ClaimsPrincipal user, string artist);
}