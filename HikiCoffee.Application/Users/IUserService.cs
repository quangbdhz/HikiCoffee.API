using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Users;
using HikiCoffee.ViewModels.Users.UserDataRequest;

namespace HikiCoffee.Application.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest loginRequest);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);


    }
}
