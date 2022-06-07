namespace HikiCoffee.ViewModels.Categories.CategoryDataRequest
{
    public class CategoryUpdateRequest
    {
        public int Id { get; set; }

        public bool? IsShowOnHome { get; set; }

        public int? ParentId { get; set; }
    }
}
