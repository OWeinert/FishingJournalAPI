using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FishingJournal.API.Helpers
{
    internal static class AuthHelper
    {
        internal static SigningCredentials GetSigningCredentials(IConfigurationSection jwtSettings)
        {
            var key = Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        internal static JwtSecurityToken GenerateTokenOptions(IConfigurationSection jwtSettings, SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings.GetSection("Issuer").Value,
            audience: jwtSettings.GetSection("Audience").Value,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("TokenLifetime").Value)),
            signingCredentials: signingCredentials);
            return tokenOptions;
        }

        internal static async Task<List<Claim>> GetClaims<TUser>(UserManager<TUser> userManager, TUser user) where TUser : IdentityUser
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email!)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
