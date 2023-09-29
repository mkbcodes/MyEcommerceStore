using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WasmStore.Server.Models;

public class CustomProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);

        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            context.IssuedClaims.AddRange(context.Subject.Claims.Where(c => c.Type == JwtClaimTypes.Role));
            context.IssuedClaims.AddRange(roles.Select(role => new Claim(JwtClaimTypes.Role, role)));
        }
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);
        context.IsActive = user != null;
    }
}
