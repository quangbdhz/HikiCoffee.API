using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.StatusTranslations;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.StatusTransaltions
{
    public class StatusTranslationService : IStatusTranslationService
    {
        private readonly HikiCoffeeDbContext _context;

        public StatusTranslationService(HikiCoffeeDbContext context)
        {
            _context = context;
        }


        public async Task<ApiResult<int>> AddStatusTranslation(int statusId, string nameStatus, int languageId)
        {
            var checkLanguage = await _context.Languages.FirstOrDefaultAsync(x => x.Id == languageId);
            if (checkLanguage == null)
                return new ApiErrorResult<int>("Language" + MessageConstants.NotFound);

            var checkTheStatusTranslation = await _context.StatusTranslations.FirstOrDefaultAsync(x => x.StatusId == statusId && x.LanguageId == languageId);
            if (checkTheStatusTranslation != null)
                return new ApiErrorResult<int>("StatusTranslation version Language already exist.");


            var checkStatus = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == statusId);

            if (checkStatus == null)
                return new ApiErrorResult<int>("Status" + MessageConstants.NotFound);

            var statusTranslation = new StatusTranslation() { StatusId = statusId, NameStatus = nameStatus, LanguageId = languageId };
            await _context.StatusTranslations.AddAsync(statusTranslation);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(MessageConstants.AddSuccess("StatusTranslation"));
        }

        public async Task<ApiResult<bool>> DeleteStatusTranslation(int id)
        {
            try
            {
                var statusTranslation = await _context.StatusTranslations.SingleOrDefaultAsync(x => x.Id == id);

                if (statusTranslation == null)
                    return new ApiErrorResult<bool>("StatusTranslation" + MessageConstants.NotFound);

                _context.StatusTranslations.Remove(statusTranslation);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete StatusTransaltion is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<StatusTranslationManagementViewModel>> GetByStatusId(int statusId)
        {
            var statusTranslations = await _context.StatusTranslations.Where(x => x.StatusId == statusId).Select(y => new StatusTranslationManagementViewModel() { 
                Id = y.Id, 
                NameStatus = y.NameStatus, 
                LanguageId = y.LanguageId, 
                StatusId = y.StatusId 
            }).ToListAsync();

            return statusTranslations;
        }

        public async Task<ApiResult<bool>> UpdateStatusTranslation(int id, string nameStatus)
        {
            try
            {
                var statusTranslation = await _context.StatusTranslations.SingleOrDefaultAsync(x => x.Id == id);

                if (statusTranslation == null)
                    return new ApiErrorResult<bool>("StatusTranslation" + MessageConstants.NotFound);

                statusTranslation.NameStatus = nameStatus;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Update StatusTransaltion is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
