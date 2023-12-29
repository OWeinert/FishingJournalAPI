using FishingJournal.API.Models.InputModels;
using Refit;

namespace FishingJournalClient.API.Endpoints;

public interface IUserApi
{
    const string BaseRoute = "/User";

    [Post($"{BaseRoute}/ChangePassword")]
    Task ChangePassword(ChangePasswordInputModel model);

    [Post($"{BaseRoute}/ChangeUsername")]
    Task ChangeUsername(ChangeNameInputModel model);

    [Post($"{BaseRoute}/Delete")]
    Task Delete(LoginInputModel model);

    [Post($"{BaseRoute}/DeleteDirect")]
    Task DeleteDirect(string email);

    [Get(BaseRoute)]
    Task GetAll();
}