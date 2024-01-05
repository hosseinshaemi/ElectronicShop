using System.Security.Claims;
namespace MyEshop.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        var isAdminClaim = user.FindFirst("IsAdmin");
        return isAdminClaim != null && bool.TryParse(isAdminClaim.Value, out var isAdmin) && isAdmin;
    }
}