using FishingJournal.API.Models.InputModels;
using Refit;

namespace FishingJournalClient.API.Endpoints;

public interface IAuthApi
{
    const string BaseRoute = "/Auth";
    
    [Post($"{BaseRoute}/Register")]
    Task<string> Register(RegisterInputModel model);

    [Post($"{BaseRoute}/Login")]
    Task<string> Login(LoginInputModel model);

    [Post($"{BaseRoute}/Logout")]
    Task Logout();
}