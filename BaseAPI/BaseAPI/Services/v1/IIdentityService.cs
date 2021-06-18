using System.Threading.Tasks;
using BaseAPI.Contracts.v1.RequestModels;
using BaseAPI.Contracts.v1.ResponseModels;

namespace BaseAPI.Services.v1
{
    public interface IIdentityService
    {
        Task<AuthenticationResponse> RegisterAsync(UserRegistrationRequest request);
        Task<AuthenticationResponse> LoginAsync(UserAuthenticationRequest request);



    }
}