using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using FrameWork.DAL.ConnectionString;
using FrameWork.DAL.DapperSQl;
using FrameWork.DAL.DapperSQL;
using FrameWork.Options;
using FrameWork.Security.Encryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using BaseAPI.Contracts.v1.DataModels;
using BaseAPI.Contracts.v1.RequestModels;
using BaseAPI.Contracts.v1.ResponseModels;


namespace BaseAPI.Services.v1
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
                var NcodeStats = NationalCodeExist(request.NationalCode, request.IsCustomer);
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
                        Token = GetToken(),
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
                if (!UserNameExist(request.UserName))
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
                    Password = user .Password,
                    Salt = user .Salt,
                    Sugar = user .Sugar
                };
                if (Encryption.IsEqual(encrypted, request.Password))
                {
                    return new AuthenticationResponse
                    {
                        Success = true,
                        Token = GetToken(),
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

        private string GetToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "newuser.email"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, "email"),
                    new Claim("id", "id")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); 
        }
        private bool NationalCodeExist(string NationalCode, int IsCustomer)
        {
            var parameter = new List<InputParameters>();
            parameter.Add(new InputParameters("NationalCode", NationalCode, ParameterTypes.String));
            var res = _dapper.Query($@"    IF EXISTS(SELECT 1 FROM Users.tblPeople P join {(IsCustomer == 1 ? "Users.tblCustomers" : "Users.tblUsers")} D on D.PeopleID = P.ID WHERE NationalCode = @NationalCode)
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
    }

}
