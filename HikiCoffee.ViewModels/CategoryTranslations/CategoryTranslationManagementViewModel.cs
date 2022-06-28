namespace HikiCoffee.ViewModels.CategoryTranslations
{
    public class CategoryTranslationManagementViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string NameCategory { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }

        public string SeoAlias { get; set; }

        public int LanguageId { get; set; }
    }
}
