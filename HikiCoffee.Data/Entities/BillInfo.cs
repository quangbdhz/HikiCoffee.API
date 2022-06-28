﻿namespace HikiCoffee.Data.Entities
{
    public class BillInfo
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public Bill Bill { get; set; }

        public Product Product { get; set; }

    }
}
