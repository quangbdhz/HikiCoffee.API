namespace HikiCoffee.ViewModels.Categories.CategoryDataRequest
{
    public class CategoryCreateRequest
    {
        public bool? IsShowOnHome { get; set; }

        public int? ParentId { get; set; }

        public string NameCategory { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }

        public int LanguageId { get; set; }
    }
}
