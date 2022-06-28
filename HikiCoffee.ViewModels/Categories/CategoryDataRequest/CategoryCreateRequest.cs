namespace HikiCoffee.ViewModels.Categories.CategoryDataRequest
{
    public class CategoryCreateRequest
    {
        public bool? IsShowOnHome { get; set; }

        public int? ParentId { get; set; }

        public string? UrlImageCoverCategory { get; set; }
    }
}
