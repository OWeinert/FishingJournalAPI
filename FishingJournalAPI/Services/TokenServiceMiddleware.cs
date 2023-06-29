using System.Net;

namespace FishingJournal.API.Services
{
    /// <summary>
    /// Based on https://piotrgankiewicz.com/2018/04/25/canceling-jwt-tokens-in-net-core/
    /// </summary>
    public class TokenServiceMiddleware : IMiddleware
    {
        private readonly ITokenService _tokenService;

        public TokenServiceMiddleware(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if(await _tokenService.IsCurrentActiveAsync())
            {
                await next(context);
                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
