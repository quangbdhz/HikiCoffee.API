using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.CoffeeTables;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Statuses;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.CoffeeTables
{
    public class CoffeeTableService : ICoffeeTableService
    {
        private readonly HikiCoffeeDbContext _context;

        public CoffeeTableService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> AddCoffeeTable(string nameCoffeeTable)
        {
            var coffeeTable = new CoffeeTable() { NameCoffeeTable = nameCoffeeTable, IsActive = true, StatusId = 3, ExpirationTime = null, AppointmentTime = null };

            await _context.CoffeeTables.AddAsync(coffeeTable);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>("Add CoffeeTable is success.");
        }

        public async Task<ApiResult<bool>> DeleteCoffeeTable(int coffeeTableId)
        {
            try
            {
                var coffeeTable = await _context.CoffeeTables.SingleOrDefaultAsync(x => x.Id == coffeeTableId);
                if (coffeeTable == null)
                    return new ApiErrorResult<bool>("CoffeeTable" + MessageConstants.NotFound);

                coffeeTable.IsActive = !coffeeTable.IsActive;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete CoffeeTable is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<CoffeTableViewModel>> GetAll(int languageIdStatus)
        {
            var query = from c in _context.CoffeeTables
                        where c.IsActive == true
                        join s in _context.Statuses on c.StatusId equals s.Id
                        join st in _context.StatusTranslations on s.Id equals st.StatusId
                        where st.LanguageId == languageIdStatus
                        select new { c, s, st };

            var data = await query.Select(x => new CoffeTableViewModel() { 
                Id = x.c.Id, 
                AppointmentTime = x.c.AppointmentTime, 
                ExpirationTime = x.c.ExpirationTime, 
                IsActive = x.c.IsActive, 
                NameCoffeeTable = x.c.NameCoffeeTable, 
                StatusViewModel = new StatusViewModel() 
                { 
                    Id = x.s.Id, DateCreated = x.s.DateCreated, IsActive = x.s.IsActive, NameStatus = x.st.NameStatus, LanguageId = x.st.LanguageId 
                } 
            }).ToListAsync();

            return data;
        }

        public async Task<ApiResult<CoffeTableViewModel>> GetById(int coffeeTableId, int languageIdStatus)
        {
            var query = from c in _context.CoffeeTables where c.Id == coffeeTableId
                        where c.IsActive == true
                        join s in _context.Statuses on c.StatusId equals s.Id
                        join st in _context.StatusTranslations on s.Id equals st.StatusId
                        where st.LanguageId == languageIdStatus
                        select new { c, s, st };

            var result = await query.Select(x => new CoffeTableViewModel()
            {
                Id = x.c.Id,
                AppointmentTime = x.c.AppointmentTime,
                ExpirationTime = x.c.ExpirationTime,
                IsActive = x.c.IsActive,
                NameCoffeeTable = x.c.NameCoffeeTable,
                StatusViewModel = new StatusViewModel()
                {
                    Id = x.s.Id,
                    DateCreated = x.s.DateCreated,
                    IsActive = x.s.IsActive,
                    NameStatus = x.st.NameStatus,
                    LanguageId = x.st.LanguageId
                }
            }).FirstOrDefaultAsync();

            if (result == null)
                return new ApiErrorResult<CoffeTableViewModel>("CoffeeTable" + MessageConstants.NotFound);

            return new ApiSuccessResult<CoffeTableViewModel>(result);
        }

        public async Task<ApiResult<bool>> UpdateCoffeeTable(int coffeeTableId, string nameCoffeeTable)
        {
            try
            {
                var coffeeTable = await _context.CoffeeTables.SingleOrDefaultAsync(x => x.Id == coffeeTableId);
                if (coffeeTable == null)
                    return new ApiErrorResult<bool>("CoffeeTable" + MessageConstants.NotFound);

                coffeeTable.NameCoffeeTable = nameCoffeeTable;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Update CoffeeTable is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
