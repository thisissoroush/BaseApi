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
using FrameWork.DAL.EF.Repositories;
using FrameWork.DAL.EF.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BaseAPI.Controllers
{

    public class TestController : Controller
    {
        private readonly IDbConnector _conStr;
        private readonly IDapper<TestClass> _dapper;
        private readonly IMemoryCache _Cache;
        private IIdentityService _IdentityService;
        private IRepository<TblUser> _user;
        public TestController(IDbConnector constr, IDapper<TestClass> dapper, IMemoryCache Cache, IIdentityService IdentityService, 
            IHttpContextAccessor accessor, IRepository<TblUser> User) 
            //:base(accessor,IdentityService) 
        {
            _conStr = constr;
            _dapper = dapper;
            _Cache = Cache;
            _user = User;
        }
        
        
        [HttpGet(ApiRoutes.Test.GetAll)]
        public async Task<IActionResult> GetAll(string token = "")
        {

            IReadOnlyList<TblUser> result = new List<TblUser>() { };
            #region MemCache
            var cacheKey = "users";
            if (!_Cache.TryGetValue(cacheKey, out result))
            {
                result = await _user.GetAsync(null, q => q.OrderBy(c => c.Id));
                _Cache.Set(cacheKey, result);
                _Cache.Remove(cacheKey);
            }
            
            #endregion

            return Ok(result);
            string res = "";

            #region DAL

            var cnt = await _user.CountAsync(q=>q.Id==3 || (q.UserName == q.UserName && q.LastName == "test"));
            var tmp = await _user.GetByIdAsync((long)3);
            var x = await _user.ListAllAsync();
            await _user.DeleteAsync(5);

            
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