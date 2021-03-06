namespace HikiCoffee.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public int SortOrder { get; set; }

        public string? UrlImageCoverCategory { get; set; }

        public bool? IsShowOnHome { get; set; }

        public int? ParentId { get; set; }

        public bool IsActive { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
