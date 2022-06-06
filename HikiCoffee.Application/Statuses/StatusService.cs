using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Statuses;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.Statuses
{
    public class StatusService : IStatusService
    {
        private readonly HikiCoffeeDbContext _context;

        public StatusService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> AddStatus()
        {
            var status = new Status() { IsActive = true, DateCreated = DateTime.Now };
            await _context.Statuses.AddAsync(status);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(status.Id);
        }

        public async Task<ApiResult<bool>> DeleteStatus(int statusId)
        {
            try
            {
                var status = await _context.Statuses.SingleOrDefaultAsync(x => x.Id == statusId);

                if (status == null)
                    return new ApiErrorResult<bool>("Status" + MessageConstants.NotFound);

                status.IsActive = !status.IsActive;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete Status is success.");

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);    
            }
        }

        public async Task<List<StatusViewModel>> GetAll(int languageId)
        {
            var query = from s in _context.Statuses
                        join st in _context.StatusTranslations on s.Id equals st.StatusId
                        where st.LanguageId == languageId
                        select new { s, st };

            var data = await query.Select(x => new StatusViewModel() { Id = x.s.Id, DateCreated = x.s.DateCreated, IsActive = x.s.IsActive, NameStatus = x.st.NameStatus, LanguageId = x.st.LanguageId }).ToListAsync();

            return data;
        }

        public async Task<ApiResult<StatusViewModel?>> GetById(int statusId, int languageId)
        {
            var query = from s in _context.Statuses where s.Id == statusId
                        join st in _context.StatusTranslations on s.Id equals st.StatusId
                        where st.LanguageId == languageId
                        select new { s, st };

            try
            {
                var data = await query.Select(x => new StatusViewModel() { Id = x.s.Id, DateCreated = x.s.DateCreated, IsActive = x.s.IsActive, NameStatus = x.st.NameStatus, LanguageId = x.st.LanguageId }).SingleOrDefaultAsync();

                if (data == null)
                    return new ApiErrorResult<StatusViewModel?>("Status" + MessageConstants.NotFound);

                return new ApiSuccessResult<StatusViewModel?>(data);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<StatusViewModel?>(ex.Message);
            }
        }

        public async Task<PagedResult<StatusManagementViewModel>> GetPagingStatusManagements(PagingRequestBase request)
        {
            var query = from s in _context.Statuses select s;

            var statuses = await _context.Statuses.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new StatusManagementViewModel() 
            { 
                Id = x.Id, 
                DateCreated = x.DateCreated, 
                IsActive = x.IsActive
            }).ToListAsync();

            int totalRow = await query.CountAsync();

            var pagedResult = new PagedResult<StatusManagementViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = statuses
            };

            return pagedResult;
        }
    }
}
