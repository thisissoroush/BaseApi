using Microsoft.AspNetCore.Mvc;
using BaseAPI.Contracts.v1;
using FrameWork.DAL.ConnectionString;
using FrameWork.DAL.DapperSQl;
using Microsoft.Extensions.Caching.Memory;
using System;
using Microsoft.AspNetCore.Authorization;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Services.v1.Identity;
using Microsoft.AspNetCore.Http;

namespace BaseAPI.Controllers
{

    public class TestController : BaseController
    {
        private readonly IDbConnector _conStr;
        private readonly IDapper<TestClass> _dapper;
        private readonly IMemoryCache _Cache;
        private IIdentityService _IdentityService;
        public TestController(IDbConnector constr, IDapper<TestClass> dapper, IMemoryCache Cache, IIdentityService IdentityService, 
            IHttpContextAccessor accessor) :base(accessor,IdentityService) {
            _conStr = constr;
            _dapper = dapper;
            _Cache = Cache;
        }
        
        
        [HttpGet(ApiRoutes.Test.GetAll)]
        public IActionResult GetAll(string token = "")
        {
            string res = "";
            
            #region DAL
            ////query
            //var parameter = new List<InputParameters>();
            //parameter.Add(new InputParameters("@one", "1", ParameterTypes.Integer));
            //var res = _dapper.Query("SELECT * FROM Users.tblPeople",parameter);

            ////ExecuteReader
            //var parameter = new List<InputParameters>();
            //parameter.Add(new InputParameters("@one", "1", ParameterTypes.Integer));
            //var res = _dapper.ExecuteReader("USP_TestProc",parameter);

            ////Execute
            //var parameter = new List<InputParameters>();
            //parameter.Add(new InputParameters("@one", "1", ParameterTypes.Integer));
            //_dapper.Execute("USP_TestProc",parameter);

            //return Ok(res.Result);
            #endregion
            #region MemCache
            //var cacheKey = "TheTime";
            //DateTime existingTime;
            //if (_Cache.TryGetValue(cacheKey, out existingTime))
            //{
            //   res =  "Fetched from cache : " + existingTime.ToString();
            //    _Cache.Remove(cacheKey);
            //}
            //else
            //{
            //    existingTime = DateTime.UtcNow;
            //    _Cache.Set(cacheKey, existingTime);
            //    res = "Added to cache : " + existingTime;
            //}
            #endregion

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Ok(_IdentityService.GetUserDataFromToken(token));
            }
            return Ok(new { message = $"Hi! APiWorks. {res}" });
        }
    }
    public class TestClass
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }


    }
}