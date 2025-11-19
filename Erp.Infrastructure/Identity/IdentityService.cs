using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Erp.Application.Common.Exceptions;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Application.Auth;
using Erp.Domain.Enums;
using Erp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Erp.Application.Auth.Commands;
using Microsoft.AspNetCore.WebUtilities;

using Erp.Infrastructure.Services;
using Dapper;
using Erp.Application.Auth.RoleManagement;
using System.Data;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Dynamic;
using YamlDotNet.Core.Tokens;
using System.Text.Json;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Tls;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Erp.Infrastructure.Identity
{
    public class IdentityService : DbContext<UserForLoginDto>, IIdentityService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
       
      
        private const string BaseUrl = "http://192.168.1.86/api/AnotherApps/GetEmployeeChecked?id=1&name=sng&employeeID=";

        private readonly HttpClient _client;
        public IdentityService(ApplicationDbContext dbcontext, IConfiguration configuration, UserManager<User> userManager,
            SignInManager<User> signInManager,
            HttpClient client) : base(configuration)
        {
            _context = dbcontext;
            _config = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _client = client;
      

        }

        //public IdentityService(ApplicationDbContext context,
        //    IConfiguration config,
        //    UserManager<User> userManager,
        //    SignInManager<User> signInManager,
        //    IHelperService helperService,
        //    HttpClient client,
        //    ICompanyService companyService,
        //    IBranchUser service
        //)
        //{
        //    _context = context;
        //    _config = config;
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _client = client;
        //    _helperService = helperService;

        //    _companyService = companyService;
        //    _service = service;

        //}



        public async Task<object> Login(UserForLoginDto userForLogin)
        {
            if (!string.IsNullOrWhiteSpace(userForLogin.UserName) && !string.IsNullOrWhiteSpace(userForLogin.Password))
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.EmployeeId == userForLogin.UserName) ??
                           (await _userManager.FindByEmailAsync(userForLogin.UserName) ?? await _userManager.FindByNameAsync(userForLogin.UserName));
                if (user == null)
                {
                    throw new UnauthorizedAccessException("User not found! Please register");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, userForLogin.Password, false);

                if (result.Succeeded)
                {
                    //var finYearObj = await _finYear.GetFinYearById(userForLogin.FinYearId);
                    //var companyObj = await _companyService.GetCompanyById(userForLogin.BranchOfficeId);
                    //user.BranchOfficeId = userForLogin.BranchOfficeId;
                    //user.FinYearId = userForLogin.FinYearId;
                    UserForReturnDto appUser = new UserForReturnDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        //Email = user.Email,
                        //EmployeeId = user.EmployeeId,
                        //PhoneNumber = user.PhoneNumber,
                        //HeadOfficeId = user.HeadOfficeId,
                        //BranchOfficeId = companyObj.Id,
                        //  FinYearId = finYearObj.YearNo,
                        //FinYearTitle = finYearObj.YearTitle,
                        //BranchOfficeName = companyObj.BranchOfficeName
                    };

                    return new
                    {
                        token = GenerateJwtToken(user).Result,
                        user = appUser
                    };
                }

                throw new UnauthorizedAccessException("Invalid username or password");
            }


            throw new NotFoundException(nameof(User), userForLogin.UserName);
        }

        public static string EncryptPassword(string password)
        {
            // Step 1: Use SHA256 to hash the password
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the password string to a byte array and hash it
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Step 2: Convert the hashed bytes to a Base64 string
                return Convert.ToBase64String(bytes);
            }
        }

        public async Task<List<UserCreateDto>> LoginNew(UserForLoginDto userForLogin)
        {
            if (!string.IsNullOrWhiteSpace(userForLogin.UserName) && !string.IsNullOrWhiteSpace(userForLogin.Password))
            {
                List<UserCreateDto> _Lst = new List<UserCreateDto>();

                string passPhrase = "Pas5pr@se";
                string saltValue = "s@1tValue";
                string hashAlgorithm = "SHA1";
                int passwordIterations = 2;
                string initVector = "@1B2c3D4e5F6g7H8";
                int keySize = 256;



                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(userForLogin.Password);

                PasswordDeriveBytes password = new PasswordDeriveBytes(
                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);


                RijndaelManaged symmetricKey = new RijndaelManaged();


                symmetricKey.Mode = CipherMode.CBC;


                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);


                MemoryStream memoryStream = new MemoryStream();


                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                             encryptor,
                                                             CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);


                cryptoStream.FlushFinalBlock();


                byte[] cipherTextBytes = memoryStream.ToArray();


                memoryStream.Close();
                cryptoStream.Close();


                string decryptText = Convert.ToBase64String(cipherTextBytes);


                //============encrypt password=============
                //byte[] storePassword = ASCIIEncoding.ASCII.GetBytes(userForLogin.Password);
                //string encryptedPassword = Convert.ToBase64String(storePassword);
                //==============decrypt password================
               // byte[] increptedPass = Convert.FromBase64String(encryptedPassword);
                //string decryptedPassword = ASCIIEncoding.ASCII.GetString(increptedPass);
               
                DynamicParameters parameter = new DynamicParameters();
               // string dd = pass;
                string query = "usp_Check_User_Info";
                parameter.Add("UserName", userForLogin.UserName, DbType.String, ParameterDirection.Input);
                parameter.Add("Password", decryptText, DbType.String, ParameterDirection.Input);

                var GetUserlist = await GetDisposeErrorFreeListAsyncNew<UserCreateDto>(query, parameter);
                if (GetUserlist == null)
                {
                    throw new UnauthorizedAccessException("User not found! Please register");
                }
                else
                {

                    foreach (var item in GetUserlist)
                    {
                        var obj = new UserCreateDto
                        {
                            User_Create_Id = item.User_Create_Id,
                            User_Name = item.User_Name,
                            Login_Name = item.Login_Name,
                            DesigEName = item.DesigEName,
                            User_Emp_Code = item.User_Emp_Code,
                            ImageData = item.ImageData,
                            token = ""
                        };
                        _Lst.Add(obj);

                    }
                    _Lst[0].token = GenerateJwtTokenNew(_Lst[0]).Result;


                    //  string json = resultList[0].ToString().Replace("{DapperRow, ", "").TrimEnd('}');

                    // Deserialize the JSON string into a DapperRow object
                    //  UserCreateDto dapperRow = JsonSerializer.Deserialize<UserCreateDto>(json);
                    // string _data = resultList[0].ToString();
                    // var keyValPairs = _data.Split(new[] { ',', '{', '}', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    // var properties = new Dictionary<string, string>();

                    //string[] keyValuePairs = resultList[0].ToString().Trim('{', '}').Split(new[] { ',', '=' }, StringSplitOptions.RemoveEmptyEntries);


                    // for (int i = 1; i < keyValuePairs.Length; i += 2)
                    // {
                    //     properties[keyValuePairs[i].Trim()] = keyValuePairs[i + 1].Trim('\'', ' ');
                    // }

                    // // Create a new DapperRow object
                    // UserCreateDto _obj = new UserCreateDto
                    // {
                    //     User_Create_Id = Convert.ToInt32(properties["User_Create_Id"]),
                    //     School_Name_Id = Convert.ToInt32(properties["School_Name_Id"]),
                    //     School_Branch_Id = Convert.ToInt32(properties["School_Branch_Id"]),
                    //     User_Role = properties["User_Role"],
                    //     User_Name = properties["User_Name"],
                    //     User_Emp_Code = properties["User_Emp_Code"],
                    //     User_Phone = properties["User_Phone"],
                    //     User_Email = properties["User_Email"],
                    //     User_Password = properties["User_Password"],
                    //     User_Confirm_Password = properties["User_Confirm_Password"]
                    // };


                    //UserForReturnDto appUser = new UserForReturnDto
                    //{
                    //    Id = _obj.User_Create_Id,
                    //    UserName = _obj.User_Name,
                    //};

                    //return new
                    //{
                    //    token = GenerateJwtTokenNew(_obj).Result,
                    //    user = appUser
                    //};
                    return _Lst;

                }

                throw new UnauthorizedAccessException("Invalid username or password");
            }


            throw new NotFoundException(nameof(User), userForLogin.UserName);
        }

        private async Task<string> GenerateJwtTokenNew(UserCreateDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.User_Create_Id.ToString()),
                new Claim(ClaimTypes.Name, user.User_Name),
                //new Claim(ClaimTypes.GroupSid, user.School_Name_Id.ToString()),
                //new Claim(ClaimTypes.PrimarySid, user.School_Branch_Id.ToString()),

            };

            if (!string.IsNullOrWhiteSpace(user.User_Emp_Code))
            {
                claims.Add(new Claim(ClaimTypes.SerialNumber, user.User_Emp_Code));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(9),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        //public async Task<object> Login(UserForLoginDto userForLogin)
        //{
        //    if (!string.IsNullOrWhiteSpace(userForLogin.TokenNumber))
        //    {
        //        string decrypt = _encryptDecrypt.DecryptString(userForLogin.TokenNumber);
        //        string[] words = decrypt.Split('_');
        //        string empCode = words[0].ToLower();
        //        decrypt = words[1];
        //        var userInfo = _context.Users.Where(x => x.EmployeeId.ToLower() == empCode && x.TokenNumber.ToLower() == decrypt.ToLower()).FirstOrDefaultAsync();

        //        var user = await _context.Users.FirstOrDefaultAsync(c => c.EmployeeId == empCode) ??
        //                   (await _userManager.FindByEmailAsync(userForLogin.UserName) ?? await _userManager.FindByNameAsync(empCode));

        //        if (userInfo == null)
        //        {
        //            throw new UnauthorizedAccessException("User not found! Please register");
        //        }

        //        //var result = await _signInManager.CheckPasswordSignInAsync(user, userForLogin.Password, false);

        //        if (userInfo!=null)
        //        {

        //            UserForReturnDto appUser = new UserForReturnDto
        //            {
        //                Id = user.Id,
        //                UserName = user.UserName,
        //                Email = user.Email,
        //                EmployeeId = user.EmployeeId,
        //                PhoneNumber = user.PhoneNumber,
        //                HeadOfficeId = user.HeadOfficeId,
        //                BranchOfficeId = user.BranchOfficeId,

        //            };

        //            return new
        //            {
        //                token = GenerateJwtToken(user).Result,
        //                user = appUser
        //            };
        //        }

        //        throw new UnauthorizedAccessException("Invalid username or password");
        //    }


        //    throw new NotFoundException(nameof(User), userForLogin.UserName);
        //}

        //public async Task<(Result Result, int UserId)> Register(UserForRegisterDto userForRegister)
        //{

        //    //API Validation
        //    if (userForRegister != null)
        //    {
        //        /*var httpResponse = await _client.GetAsync(
        //            $"{BaseUrl}{userForRegister.EmployeeId}");

        //        var responseMsg = await httpResponse.Content.ReadAsStringAsync();

        //        if (responseMsg.Contains("true"))
        //        {
        //            var checkUser =
        //                await _context.Users.FirstOrDefaultAsync(c => c.EmployeeId == userForRegister.EmployeeId);

        //            if (checkUser != null)
        //                return (Result.Failure(new List<string> { "User Already Exist" }), checkUser.Id);

        //            if (!string.IsNullOrWhiteSpace(userForRegister.EmployeeId))
        //            {
        //                checkUser = await _context.Users.FirstOrDefaultAsync(c =>
        //                    c.EmployeeId == userForRegister.EmployeeId);
        //                if (checkUser != null)
        //                    return (Result.Failure(new List<string> { "User Already Exist" }), checkUser.Id);
        //            }

        //            //var userInfo =
        //            //    await _context.EmployeeProfiles.FirstOrDefaultAsync(c =>
        //            //        c.EmployeeId == userForRegister.EmployeeId) ?? null;

        //            //if (userInfo != null)
        //            //{
        //                var user = new User
        //            {
        //                UserName = userForRegister.EmployeeId,
        //                EmployeeId = userForRegister.EmployeeId,
        //                HeadOfficeId = 331,
        //                BranchOfficeId = 4
        //            };

        //            var result = await _userManager.CreateAsync(user, userForRegister.Password);

        //            if (result.Succeeded)
        //            {
        //                var userForRole = await _userManager.FindByNameAsync(user.UserName);
        //                await _userManager.AddToRolesAsync(userForRole, new[] { UsersRole.Employee.ToString() });
        //            }

        //            return (result.ToApplicationResult(), user.Id);
        //            //}
        //        }*/

        //        //normal validation

        //        //else
        //        //{
        //        //if (await _helperService.GetEmployeeIdValidation(userForRegister.EmployeeId))
        //        //{
        //        var checkUser =
        //            await _context.Users.FirstOrDefaultAsync(
        //                c => c.EmployeeId == userForRegister.EmployeeId);

        //        if (checkUser != null)
        //            return (Result.Failure(new List<string> { "User Already Exist" }), checkUser.Id);

        //        if (!string.IsNullOrWhiteSpace(userForRegister.EmployeeId))
        //        {
        //            checkUser = await _context.Users.FirstOrDefaultAsync(c =>
        //                c.EmployeeId == userForRegister.EmployeeId);
        //            if (checkUser != null)
        //                return (Result.Failure(new List<string> { "User Already Exist" }), checkUser.Id);
        //        }

        //        var userInfo =
        //            await _context.EmployeeProfiles.FirstOrDefaultAsync(c =>
        //                c.EmployeeId == userForRegister.EmployeeId) ?? null;

        //        //if (userInfo != null)
        //        //{
        //        var user = new User
        //        {
        //            UserName = userForRegister.EmployeeId,
        //            EmployeeId = userForRegister.EmployeeId, //userInfo.EmployeeId,
        //            HeadOfficeId = 331,// userInfo.HeadOfficeId,
        //            BranchOfficeId = userForRegister.BranchOfficeId,
        //            EmailConfirmed = true
        //        };

        //        var result = await _userManager.CreateAsync(user, userForRegister.Password);

        //        if (result.Succeeded)
        //        {
        //            var userForRole = await _userManager.FindByNameAsync(user.UserName);
        //            await _userManager.AddToRolesAsync(userForRole,
        //                new[] { UsersRole.Employee.ToString() });
        //        }

        //        return (result.ToApplicationResult(), user.Id);
        //        //}

        //        //}
        //        //}
        //    }
        //    return (Result.Failure(new List<string> { "Employee Id not found" }), 1);
        //    //return (Result.Failure(new List<string> { "No User Found" }), checkUser.Id);
        //}


        public async Task<Result> DeleteUser(int id)
        {

            if (id > 0)
            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
                user.Deleted = true;
                await _context.SaveChangesAsync();
                return (Result.Success("User Deleted Successfully.."));
            }
            else
            {
                return (Result.Failure(new List<string> { "User Not Found!!" }));
            }

        }
        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GroupSid, user.HeadOfficeId.ToString()),
                new Claim(ClaimTypes.PrimarySid, user.BranchOfficeId.ToString()),
                new Claim(ClaimTypes.PrimaryGroupSid, user.FinYearId.ToString())

            };

            if (!string.IsNullOrWhiteSpace(user.EmployeeId))
            {
                claims.Add(new Claim(ClaimTypes.SerialNumber, user.EmployeeId));
            }

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(9),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<Result> ResetPasswordForAdmin(ResetPasswordForAdmin model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var enCodedToken = Encoding.UTF8.GetBytes(token);
            //var validToken = WebEncoders.Base64UrlEncode(enCodedToken);
            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
            return (Result.Success("Password Reset Successfully.."));
        }

   
    }
}

//string[] words = tokenNumber.Split('_');
//string empCode = words[0].ToLower();
//tokenNumber = words[1];
//_obj.MgsRead = _obj.Cmn.FindMgsSingle(0);

//var userInfo = _obj.Db.AdminUserDatas.Where(l => l.EmpCode.ToLower() == empCode && l.Active == 1).FirstOrDefault();
//if (userInfo != null && !string.IsNullOrEmpty(userInfo.MacAddress) && userInfo.MacAddress.ToLower() == tokenNumber.ToLower())
//{
