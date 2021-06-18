using System.Threading.Tasks;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Contracts.v1.RequestModels;
using BaseAPI.Contracts.v1.ResponseModels;

namespace BaseAPI.Services.v1.Identity
{
    public interface IIdentityService
    {
        Task<AuthenticationResponse> RegisterAsync(UserRegistrationRequest request);
        Task<AuthenticationResponse> LoginAsync(UserAuthenticationRequest request);
        UserDataModel GetUserDataFromToken(string Token);
    }
}