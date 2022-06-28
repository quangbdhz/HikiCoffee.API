﻿namespace HikiCoffee.ViewModels.BillInfos.BillInfoDataRequest
{
    public class BillInfoUpdateRequest
    {
        public int BillId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
