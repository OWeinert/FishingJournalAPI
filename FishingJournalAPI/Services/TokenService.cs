using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace FishingJournal.API.Services
{
    /// <summary>
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
