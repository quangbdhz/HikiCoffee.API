namespace HikiCoffee.Data.Entities
{
    public class StatusTranslation
    {
        public int Id { get; set; }

        public int StatusId { get; set; }

        public int LanguageId { get; set; }

        public string NameStatus { get; set; }


        public Status Status { get; set; }

        public Language Language { get; set; }
    }
}
