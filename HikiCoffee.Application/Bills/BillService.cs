using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
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

        public async Task<ApiResult<bool>> CheckOutBill(int billId, double totalPayPrice)
        {
            try
            {
                var bill = await _context.Bills.SingleOrDefaultAsync(x => x.Id == billId);

                if (bill == null)
                    return new ApiErrorResult<bool>("Bill" + MessageConstants.NotFound);

                bill.TotalPayPrice = totalPayPrice;
                bill.DateCheckOut = DateTime.Now;
                bill.StatusId = 1;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Checkout is success.");
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
