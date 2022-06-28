using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Genders;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.Genders
{
    public class GenderService : IGenderService
    {
        private readonly HikiCoffeeDbContext _context;

        public GenderService(HikiCoffeeDbContext context)
        {
            _context = context;
        }


        public async Task<ApiResult<bool>> AddGender(string nameGender)
        {
            var gender = new Gender() { NameGender = nameGender };
            await _context.Genders.AddAsync(gender);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>("Add Gender is success.");
        }

        public async Task<ApiResult<bool>> DeleteGender(int genderId)
        {
            try
            {
                var gender = await _context.Genders.SingleOrDefaultAsync(x => x.Id == genderId);
                if (gender == null)
                    return new ApiErrorResult<bool>("Gender" + MessageConstants.NotFound);

                gender.IsActive = !gender.IsActive;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete Gender is success.");
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<GenderViewModel>> GetAllForClient()
        {
            var query = from g in _context.Genders where g.IsActive == true select new { g };

            var genders = await query.Select(x => new GenderViewModel() { Id = x.g.Id, NameGender = x.g.NameGender, IsActive = x.g.IsActive }).ToListAsync();

            return genders;
        }

        public async Task<List<GenderViewModel>> GetAllForManager()
        {
            var query = from g in _context.Genders select new { g };

            var genders = await query.Select(x => new GenderViewModel() { Id = x.g.Id, NameGender = x.g.NameGender, IsActive = x.g.IsActive }).ToListAsync();

            return genders;
        }

        public async Task<ApiResult<GenderViewModel>> GetById(int genderId)
        {
            var query = from g in _context.Genders where g.Id == genderId select new { g };

            try
            {
                var gender = await query.Select(x => new GenderViewModel() { Id = x.g.Id, NameGender = x.g.NameGender, IsActive = x.g.IsActive }).SingleOrDefaultAsync();

                if (gender == null)
                    return new ApiSuccessResult<GenderViewModel>("Gender" + MessageConstants.NotFound);

                return new ApiSuccessResult<GenderViewModel>(gender);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<GenderViewModel>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> UpdateGender(int genderId, string nameGender)
        {
            try
            {
                var gender = await _context.Genders.SingleOrDefaultAsync(x => x.Id == genderId);
                if (gender == null)
                    return new ApiErrorResult<bool>("Gender" + MessageConstants.NotFound);

                gender.NameGender = nameGender;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Update Gender is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
