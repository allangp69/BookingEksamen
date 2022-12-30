using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BookingEksamenWebUI.Helpers;

public class IsSignedInHelper
    : IIsSignedInHelper
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public IsSignedInHelper(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<bool> IsSignedIn(ClaimsPrincipal user)
    {
        return _signInManager.IsSignedIn(user);
    }

    public async Task<bool> IsInRole(ClaimsPrincipal user, string role)
    {
        var identityUser = await _signInManager.UserManager.GetUserAsync(user);
        var roles = await _signInManager.UserManager.GetRolesAsync(identityUser);
        return roles.Any(r => r == role);
    }
}