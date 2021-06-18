using Newtonsoft.Json;

namespace BaseAPI.Contracts.v1.DataModels
{
    public class UserDataModel
    {
        public string ID { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public string Salt { get; set; }

        [JsonIgnore]
        public string Sugar { get; set; }
        public string TypeID { get; set; }
        public string OrganizationID { get; set; }
        public string BranchID { get; set; }
        public string IsCustomer { get; set; }
        public string IP { get; set; }



    }
}
