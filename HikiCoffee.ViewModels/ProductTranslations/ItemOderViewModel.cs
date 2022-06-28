namespace HikiCoffee.ViewModels.ProductTranslations
{
    public class ItemOderViewModel
    {
        public int ProductId { get; set; }

        public string NameProduct { get; set; }

        public int LanguageId { get; set; }

        public string? NameUnit { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }
    }
}
