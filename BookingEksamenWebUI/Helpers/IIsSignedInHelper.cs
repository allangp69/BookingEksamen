using System.Security.Claims;

namespace BookingEksamenUI.Helpers;

public interface IIsSignedInHelper
{
    bool IsSignedIn(ClaimsPrincipal user);
}