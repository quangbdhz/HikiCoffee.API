namespace HikiCoffee.ViewModels.Categories
{
    public class CategoryManagementViewModel
    {
            public int Id { get; set; }

            public int SortOrder { get; set; }

            public bool? IsShowOnHome { get; set; }

            public int? ParentId { get; set; }

            public bool IsActive { get; set; }

            public string? UrlImageCoverCategory { get; set; }
    }
}
