
namespace BaseAPI.Contracts.v1.RequestModels
{
    public class UserAuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsCustomer { get; set; }
    }
}
