using HikiCoffee.ViewModels.BillInfos;

namespace HikiCoffee.ViewModels.Bills
{
    public class BillViewModel
    {
        public int Id { get; set; }

        public int CoffeeTabelId { get; set; }

        public Guid UserPaymentId { get; set; }

        public Guid UserCustomerId { get; set; }

        public DateTime DateCheckIn { get; set; }

        public DateTime? DateCheckOut { get; set; }

        public double TotalPayPrice { get; set; }

        public List<BillInfoViewModel?> BillInfos { get; set; }
    }
}
