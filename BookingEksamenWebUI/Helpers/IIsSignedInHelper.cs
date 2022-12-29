using System.Security.Claims;

namespace BookingEksamenWebUI.Helpers;

public interface IIsSignedInHelper
{
    bool IsSignedIn(ClaimsPrincipal user);
}