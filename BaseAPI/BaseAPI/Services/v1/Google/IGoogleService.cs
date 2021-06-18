using System.Collections.Generic;
using System.Threading.Tasks;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Contracts.v1.RequestModels;

namespace BaseAPI.Services.v1.Google
{
    public interface IGoogleService
    {
        Task<List<GoogleSearchDataModel>> GetSearchQueries(string CustomerID = "");
        Task AddSearchQuery(GoogleSearchDataModel SearchQuery);
        Task SetResults(GoogleSearchRequest request, string IP);
        Task AddGoogleLog(GoogleSearchRequest request, string IP, string LogType);
    }
}