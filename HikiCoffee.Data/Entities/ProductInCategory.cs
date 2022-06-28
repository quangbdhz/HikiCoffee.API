namespace HikiCoffee.Data.Entities
{
    public class ProductInCategory
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }


        public Product Product { get; set; }

        public Category Category { get; set; }
    }
}
