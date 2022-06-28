using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.CoffeeTables;
using HikiCoffee.ViewModels.CoffeeTables.CoffeeTableDataRequest;
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

        public async Task<ApiResult<int>> AddCoffeeTable(string nameCoffeeTable)
        {
            var coffeeTable = new CoffeeTable() { NameCoffeeTable = nameCoffeeTable, IsActive = true, StatusId = 3, ExpirationTime = null, AppointmentTime = null };

            await _context.CoffeeTables.AddAsync(coffeeTable);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(MessageConstants.AddSuccess("Coffee Table"));
        }

        public async Task<ApiResult<bool>> ChangeStatusCoffeeTable(ChangeStatusCoffeeTableRequest request)
        {
            try
            {
                var coffeeTable = await _context.CoffeeTables.SingleOrDefaultAsync(x => x.Id == request.CoffeeTableId);
                if (coffeeTable == null)
                    return new ApiErrorResult<bool>("CoffeeTable" + MessageConstants.NotFound);

                coffeeTable.StatusId = request.StatusId;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Update Status CoffeeTable is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
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

        public async Task<List<CoffeeTableManagementViewModel>> GetAllCoffeeTaleManagements()
        {
            var data = await _context.CoffeeTables.Select(x => new CoffeeTableManagementViewModel()
            {
                Id = x.Id,
                AppointmentTime = x.AppointmentTime,
                ExpirationTime = x.ExpirationTime,
                IsActive = x.IsActive,
                NameCoffeeTable = x.NameCoffeeTable,
                StatusId = x.StatusId,
                NameStatus = ""
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

                return new ApiSuccessResult<bool>(MessageConstants.UpdateSuccess("CoffeeTablle"));
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> ChangeCoffeeTableIdInBill(ChangeCoffeeTableIdInBillRequest request)
        {
            try
            {
                var bill = await _context.Bills.SingleOrDefaultAsync(x => x.Id == request.BillId);
                if (bill == null)
                    return new ApiErrorResult<bool>("Bill" + MessageConstants.NotFound);

                var oldCoffeeTable = await _context.CoffeeTables.SingleOrDefaultAsync(x => x.Id == bill.CoffeeTabelId);
                if (oldCoffeeTable == null)
                    return new ApiErrorResult<bool>("Old Coffee Table" + MessageConstants.NotFound);

                var newCoffeeTable = await _context.CoffeeTables.SingleOrDefaultAsync(x => x.Id == request.NewCoffeeTableId);
                if (newCoffeeTable == null)
                    return new ApiErrorResult<bool>("New Coffee Table" + MessageConstants.NotFound);

                oldCoffeeTable.StatusId = 3;
                await _context.SaveChangesAsync();

                newCoffeeTable.StatusId = 4;
                await _context.SaveChangesAsync();

                bill.CoffeeTabelId = request.NewCoffeeTableId;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Change Coffee Table is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
