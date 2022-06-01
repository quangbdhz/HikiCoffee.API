namespace HikiCoffee.ViewModels.Statuses
{
    public class StatusViewModel
    {
        public int Id { get; set; }

        public string NameStatus { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public int LanguageId { get; set; }
    }
}
