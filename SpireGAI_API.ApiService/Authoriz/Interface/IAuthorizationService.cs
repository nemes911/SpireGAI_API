using SpireGAI_API.ApiService.Authoriz.Models;

namespace SpireGAI_API.ApiService.Authoriz.Interface
{
    public interface IAuthorizationService
    {
        Task<OutLoginUserModel> AuthorizationAsync(LoginUserModel request);
    }
}
