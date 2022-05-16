using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Users;
using HikiCoffee.ViewModels.Users.UserDataRequest;

namespace HikiCoffee.Application.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(UserLoginRequest loginRequest);

        Task<ApiResult<bool>> Register(UserRegisterRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<UserViewModel>> GetByEmail(string email);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<bool>> Delete(Guid id);

    }
}
