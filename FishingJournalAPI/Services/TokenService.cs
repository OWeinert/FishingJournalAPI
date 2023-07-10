using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FishingJournal.API.Services
{
    /// <summary>
    /// Implementation of <see cref="ITokenService"/>
    /// 
    /// Based on https://piotrgankiewicz.com/2018/04/25/canceling-jwt-tokens-in-net-core/
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public TokenService(IDistributedCache cache, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _cache = cache;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        public string GenerateJwtToken(string username, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                    new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, username),
                        new Claim(JwtRegisteredClaimNames.Name, username),
                        new Claim(ClaimTypes.Role, role),
                        new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:TokenLifetime")),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> IsCurrentActiveAsync() => await IsActiveAsync(GetCurrent());

        public async Task DeactiveCurrentAsync() => await DeactiveAsync(GetCurrent());

        public async Task<bool> IsActiveAsync(string token) => await _cache.GetStringAsync(GetKey(token)) == null;

        public async Task DeactiveAsync(string token)
        {
            await _cache.SetStringAsync(GetKey(token),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.GetValue<int>("Jwt:TokenLifetime"))
                });
        }

        private string GetCurrent()
        {
            var authorizationHeader = _contextAccessor
                .HttpContext!.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single()!.Split(" ").Last();
        }

        private string GetKey(string token) => $"tokens:{token}:deactivated";
    }
}
