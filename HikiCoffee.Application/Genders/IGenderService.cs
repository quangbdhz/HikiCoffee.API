using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Genders;

namespace HikiCoffee.Application.Genders
{
    public interface IGenderService
    {
        Task<List<GenderViewModel>> GetAllForClient();

        Task<List<GenderViewModel>> GetAllForManager();

        Task<ApiResult<GenderViewModel>> GetById(int genderId);

        Task<ApiResult<bool>> AddGender(string nameGender);

        Task<ApiResult<bool>> UpdateGender(int genderId, string nameGender);

        Task<ApiResult<bool>> DeleteGender(int genderId);
    }
}
