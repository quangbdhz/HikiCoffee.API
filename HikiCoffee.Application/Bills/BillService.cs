using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Bills;
using HikiCoffee.ViewModels.Bills.BillDataRequest;
using HikiCoffee.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.Bills
{
    public class BillService : IBillService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly HikiCoffeeDbContext _context;

        public BillService(HikiCoffeeDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApiResult<int>> AddBill(BillCreateRequest request)
        {
            try
            {
                var coffeeTable = await _context.CoffeeTables.SingleOrDefaultAsync(x => x.IsActive == true && x.Id == request.CoffeeTableId);

                if (coffeeTable == null)
                    return new ApiErrorResult<int>("CoffeeTable" + MessageConstants.NotFound);

                // get User Customer
                var userCustomer = await _userManager.FindByIdAsync(request.UserCustomerId.ToString());

                if (userCustomer == null)
                    return new ApiErrorResult<int>("User ImportProduct" + MessageConstants.NotFound);

                // get User Payment
                var userPayment = await _userManager.FindByIdAsync(request.UserPaymentId.ToString());

                if (userPayment == null)
                    return new ApiErrorResult<int>("User Staff" + MessageConstants.NotFound);

                var checkUserStaff = await _userManager.GetRolesAsync(userPayment);

                if (checkUserStaff == null)
                    return new ApiErrorResult<int>("User does not have permission.");

                bool isStaff = false;

                foreach (var item in checkUserStaff)
                {
                    if (item.ToLower() == "staff")
                    {
                        isStaff = true;
                    }
                }

                if (isStaff == false)
                    return new ApiErrorResult<int>("User does not have permission.");

                var checkCoffeeTableIsFound = await _context.Bills.FirstOrDefaultAsync(x => x.CoffeeTabelId == request.CoffeeTableId && x.StatusId == 2);
                if(checkCoffeeTableIsFound != null)
                    return new ApiErrorResult<int>("CoffeeTable is not found.");

                var bill = new Bill() { DateCheckIn =  DateTime.Now, DateCheckOut = null, CoffeeTabelId = coffeeTable.Id, UserCustomerId = userCustomer.Id, UserPaymentId = userPayment.Id, TotalPayPrice = 0, StatusId = 2 };
                await _context.Bills.AddAsync(bill);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(bill.Id);

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> CheckOutBill(BillCheckOutRequest request)
        {
            try
            {
                var bill = await _context.Bills.SingleOrDefaultAsync(x => x.Id == request.BillId);

                if (bill == null)
                    return new ApiErrorResult<bool>("Bill" + MessageConstants.NotFound);

                bill.TotalPayPrice = request.TotalPayPrice;
                bill.DateCheckOut = DateTime.Now;
                bill.StatusId = 1;
                await _context.SaveChangesAsync();

                var coffeeTable = await _context.CoffeeTables.SingleOrDefaultAsync(x => x.Id == bill.CoffeeTabelId);
                if(coffeeTable != null)
                {
                    coffeeTable.StatusId = 3;
                    await _context.SaveChangesAsync();
                }

                return new ApiSuccessResult<bool>("Checkout is success.");
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<PagedResult<InfoBillCoffeeTableViewModel>> GetAllBill(PagingRequestBase request)
        {
            var query = from b in _context.Bills
                        join u in _context.Users on b.UserCustomerId equals u.Id
                        select new { b, u };

            var bills = await query.Select(x => new InfoBillCoffeeTableViewModel()
            {
                BillId = x.b.Id,
                NameCustomer = (x.u.FirstName + " " + x.u.LastName),
                UserCustomerId = x.u.Id,
                CoffeeTableId = x.b.CoffeeTabelId,
                DateCheckIn = x.b.DateCheckIn,
                DateCheckOut = x.b.DateCheckOut,
                StatusId = x.b.StatusId,
                UserPaymentId = x.b.UserPaymentId,
                TotalPayPrice = x.b.TotalPayPrice
            }).ToListAsync();

            int totalRow = query.Count();

            var pagedResult = new PagedResult<InfoBillCoffeeTableViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = bills
            };

            return pagedResult;
        }

        public async Task<InfoBillCoffeeTableViewModel?> GetBillIdOfCoffeeTable(int coffeeTableId)
        {
            try
            {
                var query = from b in _context.Bills
                            where b.CoffeeTabelId == coffeeTableId && b.StatusId == 2
                            join u in _context.Users on b.UserCustomerId equals u.Id
                            select new { b, u };

                if (query == null)
                    return null;


                var data = await query.Select(x => new InfoBillCoffeeTableViewModel()
                {
                    BillId = x.b.Id,
                    NameCustomer = (x.u.FirstName + " " + x.u.LastName),
                    UserCustomerId = x.u.Id,
                    CoffeeTableId = x.b.CoffeeTabelId,
                    DateCheckIn = x.b.DateCheckIn,
                    DateCheckOut = x.b.DateCheckOut,
                    StatusId = x.b.StatusId,
                    UserPaymentId = x.b.UserPaymentId,
                    TotalPayPrice = x.b.TotalPayPrice
                }).FirstOrDefaultAsync();

                return data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ApiResult<bool>> MergeBill(MergeBillRequest request)
        {
            try
            {
                var bill = await _context.Bills.SingleOrDefaultAsync(x => x.Id == request.BillId);

                if (bill == null)
                    return new ApiErrorResult<bool>("Bill" + MessageConstants.NotFound);

                bill.StatusId = request.StatusId;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Merge Bill is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
