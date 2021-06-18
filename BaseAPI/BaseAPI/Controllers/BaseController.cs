using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Services.v1.Identity;


namespace BaseAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IIdentityService _IdentityService;

        public UserDataModel CurrentUser { get; set; }


        public BaseController(IHttpContextAccessor accessor, IIdentityService IdentityService)
        {
            _accessor = accessor;
            _IdentityService = IdentityService;
            CurrentUser = _IdentityService.GetUserDataFromToken(_accessor.HttpContext.GetTokenAsync("access_token").Result.ToString());
            CurrentUser.IP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}