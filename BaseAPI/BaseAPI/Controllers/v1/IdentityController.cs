using Microsoft.AspNetCore.Mvc;
using BaseAPI.Services.v1.Identity;
using BaseAPI.Contracts.v1;
using System.Threading.Tasks;
using BaseAPI.Contracts.v1.RequestModels;
using BaseAPI.Contracts.v1.ResponseModels;

namespace BaseAPI.Controllers.v1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _IdentityService;

        public IdentityController(IIdentityService IdentityService)
        {
            _IdentityService = IdentityService;
        }

        [HttpPost(ApiRoutes.Identity.register)]
        public async Task<AuthenticationResponse> Register([FromBody] UserRegistrationRequest request)
        {
            return await _IdentityService.RegisterAsync(request);

        }


        [HttpPost(ApiRoutes.Identity.login)]
        public async Task<AuthenticationResponse> Login([FromBody] UserAuthenticationRequest request)
        {
            if (request != null)
            {
                return await _IdentityService.LoginAsync(request);
            }
            else
            {
                return new AuthenticationResponse() { 
                Success=false,
                Message = "Bad Request"
                };
            }

        }
    }
}