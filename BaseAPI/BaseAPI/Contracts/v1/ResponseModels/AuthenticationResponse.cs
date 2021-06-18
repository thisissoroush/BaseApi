
using BaseAPI.Contracts.v1.DataModels;

namespace BaseAPI.Contracts.v1.ResponseModels
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserDataModel UserData { get; set; }
    }
}
