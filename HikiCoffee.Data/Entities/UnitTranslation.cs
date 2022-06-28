namespace HikiCoffee.Data.Entities
{
    public class UnitTranslation
    {
        public int Id { get; set; }

        public int UnitId { get; set; }

        public string NameUnit { get; set; }

        public string MoreInfo { get; set; }

        public int LanguageId { get; set; }

        public Unit Unit { get; set; }

        public Language Language { get; set; }

    }
}
