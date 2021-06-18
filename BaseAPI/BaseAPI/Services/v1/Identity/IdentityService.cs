using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FrameWork.DAL.ConnectionString;
using FrameWork.DAL.DapperSQl;
using FrameWork.DAL.DapperSQL;
using FrameWork.Options;
using FrameWork.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Contracts.v1.RequestModels;
using BaseAPI.Contracts.v1.ResponseModels;


namespace BaseAPI.Services.v1.Identity
{
    public class IdentityService: IIdentityService
    {
        private readonly IDapper<UserDataModel> _dapper;
        private readonly JwtOptions _jwtOptions;
        public IdentityService(IDbConnector constr, IDapper<UserDataModel> dapper, JwtOptions jwtOptions)
        {
            _dapper = dapper;
            _jwtOptions = jwtOptions;
        }

       
        public async Task<AuthenticationResponse> RegisterAsync(UserRegistrationRequest request)
        {
            try
            {
                var NcodeStats = NationalCodeExist(request.NationalCode);
                var UnameStatus = UserNameExist(request.UserName, request.IsCustomer);
                if (!NcodeStats && !UnameStatus)
                {
                    EncryptionModel encrypted = new EncryptionModel();
                    encrypted = Encryption.EncryptPassword(request.Password);
                    var parameter = new List<InputParameters>();
                    parameter.Add(new InputParameters("UserName", request.UserName, ParameterTypes.String));
                    parameter.Add(new InputParameters("Password", encrypted.Password, ParameterTypes.String));
                    parameter.Add(new InputParameters("Salt", encrypted.Salt, ParameterTypes.String));
                    parameter.Add(new InputParameters("Sugar", encrypted.Sugar, ParameterTypes.String));
                    parameter.Add(new InputParameters("NationalCode", request.NationalCode, ParameterTypes.String));
                    parameter.Add(new InputParameters("FirstName", request.FirstName, ParameterTypes.String));
                    parameter.Add(new InputParameters("LastName", request.LastName, ParameterTypes.String));
                    parameter.Add(new InputParameters("IsCustomer", request.IsCustomer.ToString(), ParameterTypes.Integer));
                    parameter.Add(new InputParameters("Mobile", request.Mobile, ParameterTypes.String));


                    await _dapper.Execute("USP_RegisterUser", parameter);

                    UserDataModel user = GetUserData(request.UserName, request.IsCustomer);

                    return new AuthenticationResponse
                    {
                        Success = true,
                        Token = GetToken(user),
                        UserData = user,
                        Message = "Successful Registration."
                    };
                }
                else
                {
                    return new AuthenticationResponse
                    {
                        Success = false,
                        Token = "",
                        Message = !NcodeStats ? "National Code Already Exists." : "UserName Already Exists."
                    };
                }


               
            }
            catch(Exception ex)
            {
                return new AuthenticationResponse
                {
                    Success = false,
                    Token = "",
                    Message = "Can't Register User at This Time!" + ex.ToString()
                };
            }
        }

        public async Task<AuthenticationResponse> LoginAsync(UserAuthenticationRequest request)
        {
            try
            {
                if (!UserNameExist(request.UserName,request.IsCustomer))
                {
                    return new AuthenticationResponse
                    {
                        Success = false,
                        Token = "",
                        Message = "Username Not Exists!"
                    };
                }

                UserDataModel user = GetUserData(request.UserName, request.IsCustomer);

                EncryptionModel encrypted = new EncryptionModel() { 
                    Password = user.Password,
                    Salt = user.Salt,
                    Sugar = user.Sugar
                };
                if (Encryption.IsEqual(encrypted, request.Password))
                {
                    return new AuthenticationResponse
                    {
                        Success = true,
                        Token = GetToken(user),
                        UserData = user ,
                        Message = ""
                    };
                }
                else
                {
                    return new AuthenticationResponse
                    {
                        Success = true,
                        Token = "",
                        UserData = null,
                        Message = "Incorrect Password!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AuthenticationResponse
                {
                    Success = false,
                    Token = "",
                    Message = "Can't Authenticater User at This Time!" + ex.ToString()
                };
            }
        }

        private string GetToken(UserDataModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("ID", user.ID),
                    new Claim("NationalCode", user.NationalCode),
                    new Claim("TypeID", (user.TypeID == null ? "" : user.TypeID)),
                    new Claim("OrganizationID", (user.OrganizationID == null ? "" : user.OrganizationID)),
                    new Claim("BranchID", (user.BranchID == null ? "" : user.BranchID)),
                    new Claim("UserName", user.UserName),
                    new Claim("IsCustomer", user.IsCustomer),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token).ToString();
             
        }
        private bool NationalCodeExist(string NationalCode)
        {
            var parameter = new List<InputParameters>();
            parameter.Add(new InputParameters("NationalCode", NationalCode, ParameterTypes.String));
            var res = _dapper.Query(@"    IF EXISTS(SELECT 1 FROM Users.tblPeople WHERE NationalCode = @NationalCode)
                                                    SELECT 1 AS NationalCode
                                                ELSE
                                                    SELECT 0 AS NationalCode", parameter)[0].NationalCode;
            return res == "1" ? true : false;
        }
        private bool UserNameExist(string UserName, int IsCustomer = 1)
        {
            //UserTypes --> Customer,User

            var parameter = new List<InputParameters>();
            parameter.Add(new InputParameters("UserName", UserName, ParameterTypes.String));
            var query = string.Empty;
            if (IsCustomer == 1)
            {
                query = @"  IF EXISTS(SELECT 1 FROM Users.tblCustomers WHERE UserName = @UserName)
                                SELECT 1 AS UserName
                            ELSE
                                SELECT 0 AS UserName";
            }
            else
            {
                query = @"  IF EXISTS(SELECT 1 FROM Users.tblUsers WHERE UserName = @UserName)
	                            SELECT 1 AS UserName
                            ELSE 
	                            SELECT 0 AS UserName";
            }
            var res = _dapper.Query(query, parameter)[0].UserName;
            return res == "1" ? true : false;
        }

        private UserDataModel GetUserData(string UserName, int IsCustomer = 1)
        {
            var parameter = new List<InputParameters>();
            parameter.Add(new InputParameters("UserName", UserName, ParameterTypes.String));
            parameter.Add(new InputParameters("IsCustomer", IsCustomer.ToString(), ParameterTypes.Integer));
            List<UserDataModel> res = _dapper.ExecuteReader("USP_GetUserData", parameter);
            return res[0];
        }

        public UserDataModel GetUserDataFromToken(string Token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(Token);
            var tokenS = handler.ReadToken(Token) as JwtSecurityToken;
            return new UserDataModel { 
                UserName = tokenS.Claims.First(claim => claim.Type == "UserName").Value,
                ID = tokenS.Claims.First(claim => claim.Type == "ID").Value,
                TypeID = tokenS.Claims.First(claim => claim.Type == "TypeID").Value,
                OrganizationID = tokenS.Claims.First(claim => claim.Type == "OrganizationID").Value,
                BranchID = tokenS.Claims.First(claim => claim.Type == "BranchID").Value,
                NationalCode = tokenS.Claims.First(claim => claim.Type == "NationalCode").Value,
                IsCustomer = tokenS.Claims.First(claim => claim.Type == "IsCustomer").Value
            };
        }
    }

}
