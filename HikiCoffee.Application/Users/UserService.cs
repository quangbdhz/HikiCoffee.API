using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Users;
using HikiCoffee.ViewModels.Users.RoleDataRequest;
using HikiCoffee.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HikiCoffee.Application.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly HikiCoffeeDbContext _context;

        public UserService(HikiCoffeeDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<Guid>> Login(UserLoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.UserName);
            if (user == null) 
                return new ApiErrorResult<Guid>("User" + MessageConstants.ErrorFound);

            var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, loginRequest.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<Guid>("Incorrect login");
            }

            string token = await CreateToken(user);

            return new ApiSuccessResult<Guid>() { Message = token, ResultObj = user.Id};
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApiResult<bool>> ConfirmMail(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                user.EmailConfirmed = true;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return new ApiSuccessResult<bool>();
                }
                return new ApiErrorResult<bool>(MessageConstants.UserConfirmMailError);
            }
            return new ApiErrorResult<bool>("User Is Not Available");
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User does not exist");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var gender = await _context.Genders.SingleOrDefaultAsync(x => x.Id == user.GenderId);

            var userViewModel = new UserViewModel()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                Dob = user.Dob,
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName,
                Gender = gender != null ? gender.NameGender : "null",
                Roles = roles
            };

            return new ApiSuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<ApiResult<UserViewModel>> GetByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User does not exist");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var gender = await _context.Genders.SingleOrDefaultAsync(x => x.Id == user.GenderId);

            var userViewModel = new UserViewModel()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                Dob = user.Dob,
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName,
                Gender = gender != null ? gender.NameGender : "null",
                Roles = roles
            };

            return new ApiSuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<ApiResult<UserViewModel>> Register(UserRegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<UserViewModel>("Account already exists");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<UserViewModel>("Email already exists");
            }

            user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                GenderId = request.GenderId,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                UserViewModel userViewModel = new UserViewModel() { Id = user.Id, Dob = user.Dob, Email = user.Email, UserName = user.UserName, FirstName = user.FirstName, Gender = "", LastName = user.LastName, PhoneNumber = user.PhoneNumber };
                return new ApiSuccessResult<UserViewModel>() { ResultObj = userViewModel };
            }

            return new ApiErrorResult<UserViewModel>("Registration failed");
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Dob = request.Dob;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.GenderId = request.GenderId;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(MessageConstants.UpdateSuccess("User"));
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User" + MessageConstants.NotFound);
            }

            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(MessageConstants.DeleteSuccess("User"));
            }

            return new ApiErrorResult<bool>("Deletion failed");
        }

        public async Task<ApiResult<bool>> RefreshToken(Guid userId, string? refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return new ApiErrorResult<bool>();

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user.RefreshToken != refreshToken)
                return new ApiErrorResult<bool>("Invalid Refresh Token.");

            if (user.TokenExpires < DateTime.Now)
                return new ApiErrorResult<bool>("Token expired.");

            string token = await CreateToken(user);

            return new ApiSuccessResult<bool>(token);
        }

        public async Task<ApiResult<int>> SetRefreshToken(Guid userId, RefreshTokenViewModel refreshTokenViewModel)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return new ApiErrorResult<int>("User Does Not Exist");

            user.RefreshToken = refreshTokenViewModel.Token;
            user.TokenCreated = refreshTokenViewModel.Created;
            user.TokenExpires = refreshTokenViewModel.Expires;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>() { ResultObj = 1 };
        }

        public RefreshTokenViewModel GenerateRefreshTokenViewModel()
        {
            var refreshTokenViewModel = new RefreshTokenViewModel
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshTokenViewModel;
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>(MessageConstants.UserDoesNotExist);
            }

            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<PagedResult<UserManagementViewModel>> GetPagingUserManagements(PagingRequestBase request)
        {
            var query = from u in _context.Users
                        join g in _context.Genders on u.GenderId equals g.Id
                        select new { u, g };

            var users = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new UserManagementViewModel()
            {
                Id = x.u.Id,
                UrlImageUser = x.u.UrlImageUser,
                Dob = x.u.Dob,
                Email = x.u.Email,
                IsEmailConfirmed = x.u.EmailConfirmed,
                FirstName = x.u.FirstName,
                LastName = x.u.LastName,
                PhoneNumber = x.u.PhoneNumber,
                NameGender = x.g.NameGender,
                UserName = x.u.UserName,
                IsActive = x.u.IsActive
            }).ToListAsync();


            int totalRow = await query.CountAsync();

            var pagedResult = new PagedResult<UserManagementViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = users
            };

            return pagedResult;
        }

        public async Task<string> GetAllRoleOfUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var roles = await _userManager.GetRolesAsync(user);

            return string.Join(",", roles);
        }
    }
}
