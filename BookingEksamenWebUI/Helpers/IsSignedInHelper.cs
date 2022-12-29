using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BookingEksamenUI.Helpers;

public class IsSignedInHelper
        :IIsSignedInHelper
{
        private readonly SignInManager<IdentityUser> _signInManager;

        public IsSignedInHelper(SignInManager<IdentityUser> signInManager)
        {
                _signInManager = signInManager;
        }
        public bool IsSignedIn(ClaimsPrincipal user)
        {
                return _signInManager.IsSignedIn(user);
        }
}