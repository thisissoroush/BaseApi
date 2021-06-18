using System.Collections.Generic;
using System.Threading.Tasks;
using FrameWork.DAL.ConnectionString;
using FrameWork.DAL.DapperSQl;
using FrameWork.DAL.DapperSQL;
using FrameWork.Options;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Contracts.v1.RequestModels;

namespace BaseAPI.Services.v1.Google
{
    public class GoogleService : IGoogleService
    {
        private readonly IDapper<GoogleSearchDataModel> _dapper;
        private readonly JwtOptions _jwtOptions;
        public GoogleService(IDbConnector constr, IDapper<GoogleSearchDataModel> dapper, JwtOptions jwtOptions)
        {
            _dapper = dapper;
            _jwtOptions = jwtOptions;
        }

        public async Task AddSearchQuery(GoogleSearchDataModel SearchQuery)
        {
            var parameter = new List<InputParameters>();
            parameter.Add(new InputParameters("CustomerID", SearchQuery.CustomerID));
            parameter.Add(new InputParameters("WebSite", SearchQuery.WebSite));
            parameter.Add(new InputParameters("TagName", SearchQuery.TagName));

            await _dapper.Execute("AddGoogleSearch", parameter);
        }

        public async Task<List<GoogleSearchDataModel>> GetSearchQueries(string CustomerID = "")
        {
            if(!string.IsNullOrWhiteSpace(CustomerID))
            {
                var parameter = new List<InputParameters>();
                parameter.Add(new InputParameters("CustomerID", CustomerID));
                return _dapper.ExecuteReader("USP_GetGoogleSearchQueries",parameter);
            }

            return _dapper.ExecuteReader("USP_GetGoogleSearchQueries");
        }
        
        public async Task SetResults(GoogleSearchRequest request,string IP)
        {
            var parameter = new List<InputParameters>();
            parameter.Add(new InputParameters("ID", request.ID));
            parameter.Add(new InputParameters("IsClicked", (request.GotClicked == true ? "1" : "0")));
            parameter.Add(new InputParameters("Who", request.Who));
            parameter.Add(new InputParameters("IP", IP));
            parameter.Add(new InputParameters("UniqueID", request.UniqueID));
            
            await _dapper.Execute("USP_UpdateGoogleSearchResults",parameter);
        }
        public async Task AddGoogleLog(GoogleSearchRequest request, string IP, string LogType)
        {
            var parameter = new List<InputParameters>();
            parameter.Add(new InputParameters("ClickID", request.ID));
            parameter.Add(new InputParameters("ViewerID", request.Who));
            parameter.Add(new InputParameters("IP", IP));
            parameter.Add(new InputParameters("LogType", LogType));
            parameter.Add(new InputParameters("UniqueID", request.UniqueID));

            await _dapper.Execute("USP_AddGoogleLog", parameter);
        }
    }

}
