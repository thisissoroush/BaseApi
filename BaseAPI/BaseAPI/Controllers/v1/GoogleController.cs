using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseAPI.Contracts.v1;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Contracts.v1.RequestModels;
using BaseAPI.Services.v1.Google;
using BaseAPI.Services.v1.Identity;

namespace BaseAPI.Controllers.v1
{

    public class GoogleController : BaseController
    {
        private readonly IGoogleService _GoogleService;
        private string _user;
        public GoogleController(IGoogleService googleService, IIdentityService IdentityService, IHttpContextAccessor accessor) : base(accessor, IdentityService)
        {
            _GoogleService = googleService;
        }

        [HttpGet(ApiRoutes.Google.getSearchQueries)]
        public async Task<List<GoogleSearchDataModel>> GetSearchQueries(string UserID)
        {
            List<GoogleSearchDataModel> searchData = new List<GoogleSearchDataModel>();
            if (!string.IsNullOrWhiteSpace(UserID))
            {
                searchData = await _GoogleService.GetSearchQueries(UserID);
            }
            else
            {
                searchData = await _GoogleService.GetSearchQueries();
                foreach (GoogleSearchDataModel data in searchData)
                {
                    GoogleSearchRequest req = new GoogleSearchRequest() { ID = data.ID, GotClicked = false, UniqueID = data.UniqueID, Who = CurrentUser.ID };
                    await _GoogleService.AddGoogleLog(req, CurrentUser.IP, "1");
                }
            }
            return searchData;
        }

        [HttpPost(ApiRoutes.Google.addQuery)]
        public async Task<IActionResult> AddQuery(string WebSite, string Query)
        {


            var google = new GoogleSearchDataModel()
            {
                CustomerID = CurrentUser.ID,
                TagName = Query,
                WebSite = WebSite,
                ID = ""
            };

            await _GoogleService.AddSearchQuery(google);

            return Ok();

        }

        [HttpPost(ApiRoutes.Google.setResult)]
        public async Task SetResult([FromBody] GoogleSearchRequest request)
        {
            await _GoogleService.AddGoogleLog(request, CurrentUser.IP, (request.GotClicked ? "3" : "2"));
            await _GoogleService.SetResults(request, CurrentUser.IP);
        }

        [HttpPost(ApiRoutes.Google.whatToDo)]
        public async Task<List<string>> WhatToDo([FromBody] GoogleSearchRequest request)
        {
            await _GoogleService.AddGoogleLog(request, CurrentUser.IP, "2");
            return new List<string>() { "Next", "Next page" };

        }
    }
}