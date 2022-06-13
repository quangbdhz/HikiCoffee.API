using HikiCoffee.Data.Entities;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Users;
using HikiCoffee.ViewModels.Users.RoleDataRequest;
using HikiCoffee.ViewModels.Users.UserDataRequest;

namespace HikiCoffee.Application.Users
{
    public interface IUserService
    {
        Task<ApiResult<Guid>> Login(UserLoginRequest loginRequest);

        Task<ApiResult<bool>> ConfirmMail(string userName);

        Task<string> CreateToken(AppUser user); 

        Task<ApiResult<UserViewModel>> Register(UserRegisterRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<UserViewModel>> GetByEmail(string email);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RefreshToken(Guid userId, string? refreshToken);

        Task<ApiResult<int>> SetRefreshToken(Guid userId, RefreshTokenViewModel refreshTokenViewModel);

        RefreshTokenViewModel GenerateRefreshTokenViewModel();

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<PagedResult<UserManagementViewModel>> GetPagingUserManagements(PagingRequestBase request);

        Task<string> GetAllRoleOfUser(Guid userId);

    }
}
